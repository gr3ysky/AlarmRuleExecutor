using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using AlarmRuleExecutor.Application.Data;
using AlarmRuleExecutor.Application.Dto;
using AlarmRuleExecutor.Application.Entity;
using System;
using Microsoft.Extensions.Options;
using AlarmRuleExecutor.Application.Configuration;

namespace AlarmRuleExecutor.Application.Executor
{
    public class RuleExecutor:IRuleExecutor
    {
        private readonly IElasticSearchManager _manager;
        private readonly EmailSettings _emailSettings;

        public RuleExecutor(IElasticSearchManager manager, IOptions<EmailSettings> emailSettings)
        {
            _manager = manager;
            _emailSettings = emailSettings.Value;
        }

        public async Task<bool> Execute(SensorDto dto)
        {
            var entity = await _manager.GetAsync<Sensor>("sensor", "data", Guid.Parse(dto.SensorId)); 
            if (entity == null)
                return false;
            dto.Name = entity.Name;
            if(entity.Rules!=null && entity.Rules.Any()){
                foreach (var rule in entity.Rules)
                {
                    ExecuteRule(entity.Datatype, dto, rule);
                }

            }
            await Task.Factory.StartNew(() => _manager.Log("sensor", "history", dto));
            return true;
        }

        private void ExecuteRule(string datatype, SensorDto dto, Rule rule)
        {
            switch (datatype.ToLower())
            {
                case "0"://numeric
                    if(CheckValue(int.Parse(dto.Value),rule.Operator,int.Parse(rule.Value))){
                        foreach (var action in rule.Actions)
                        {
                            ActionPerformerFactory.Create(action.Type, _manager,_emailSettings).Perform(dto,action.Content);
                        }
                    }

                    break;
                case "1"://boolean
                    if (CheckValue(bool.Parse(dto.Value), rule.Operator, bool.Parse(rule.Value)))
                    {
                        foreach (var action in rule.Actions)
                        {
                            ActionPerformerFactory.Create(action.Type, _manager,_emailSettings).Perform(dto, action.Content);
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private bool CheckValue(int sensorValue,string ruleOperator, int ruleValue)
        {
            switch (ruleOperator)
            {
                case "1"://equal
                    return sensorValue == ruleValue;
                case "2"://notequal
                    return sensorValue != ruleValue;
                case "3"://greater
                    return sensorValue > ruleValue;
                case "4"://greaterorequal
                    return sensorValue >= ruleValue;
                case "5"://less
                    return sensorValue < ruleValue;
                case "6"://lessthanorequal
                    return sensorValue <= ruleValue;
                default:
                    return false;
            }
        }
        private bool CheckValue(bool sensorValue, string ruleOperator, bool ruleValue)
        {
            switch (ruleOperator)
            {
                case "1"://equal
                    return sensorValue == ruleValue;
                case "2"://notequal
                    return sensorValue == ruleValue;
                default:
                    return false;
            }
        }
    }
}