using System;
using System.ComponentModel.DataAnnotations;

namespace AlarmRuleExecutor.Models
{
    public enum DataType
    {
        [Display(Name="Numeric")]
        Numeric,
        [Display(Name = "Boolean")]
        Boolean
    }
}
