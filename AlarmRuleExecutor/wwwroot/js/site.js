/*
 * Note that this is toastr v2.1.3, the "latest" version in url has no more maintenance,
 * please go to https://cdnjs.com/libraries/toastr.js and pick a certain version you want to use,
 * make sure you copy the url from the website since the url may change between versions.
 * */
!function(e){e(["jquery"],function(e){return function(){function t(e,t,n){return g({type:O.error,iconClass:m().iconClasses.error,message:e,optionsOverride:n,title:t})}function n(t,n){return t||(t=m()),v=e("#"+t.containerId),v.length?v:(n&&(v=d(t)),v)}function o(e,t,n){return g({type:O.info,iconClass:m().iconClasses.info,message:e,optionsOverride:n,title:t})}function s(e){C=e}function i(e,t,n){return g({type:O.success,iconClass:m().iconClasses.success,message:e,optionsOverride:n,title:t})}function a(e,t,n){return g({type:O.warning,iconClass:m().iconClasses.warning,message:e,optionsOverride:n,title:t})}function r(e,t){var o=m();v||n(o),u(e,o,t)||l(o)}function c(t){var o=m();return v||n(o),t&&0===e(":focus",t).length?void h(t):void(v.children().length&&v.remove())}function l(t){for(var n=v.children(),o=n.length-1;o>=0;o--)u(e(n[o]),t)}function u(t,n,o){var s=!(!o||!o.force)&&o.force;return!(!t||!s&&0!==e(":focus",t).length)&&(t[n.hideMethod]({duration:n.hideDuration,easing:n.hideEasing,complete:function(){h(t)}}),!0)}function d(t){return v=e("<div/>").attr("id",t.containerId).addClass(t.positionClass),v.appendTo(e(t.target)),v}function p(){return{tapToDismiss:!0,toastClass:"toast",containerId:"toast-container",debug:!1,showMethod:"fadeIn",showDuration:300,showEasing:"swing",onShown:void 0,hideMethod:"fadeOut",hideDuration:1e3,hideEasing:"swing",onHidden:void 0,closeMethod:!1,closeDuration:!1,closeEasing:!1,closeOnHover:!0,extendedTimeOut:1e3,iconClasses:{error:"toast-error",info:"toast-info",success:"toast-success",warning:"toast-warning"},iconClass:"toast-info",positionClass:"toast-top-right",timeOut:5e3,titleClass:"toast-title",messageClass:"toast-message",escapeHtml:!1,target:"body",closeHtml:'<button type="button">&times;</button>',closeClass:"toast-close-button",newestOnTop:!0,preventDuplicates:!1,progressBar:!1,progressClass:"toast-progress",rtl:!1}}function f(e){C&&C(e)}function g(t){function o(e){return null==e&&(e=""),e.replace(/&/g,"&amp;").replace(/"/g,"&quot;").replace(/'/g,"&#39;").replace(/</g,"&lt;").replace(/>/g,"&gt;")}function s(){c(),u(),d(),p(),g(),C(),l(),i()}function i(){var e="";switch(t.iconClass){case"toast-success":case"toast-info":e="polite";break;default:e="assertive"}I.attr("aria-live",e)}function a(){E.closeOnHover&&I.hover(H,D),!E.onclick&&E.tapToDismiss&&I.click(b),E.closeButton&&j&&j.click(function(e){e.stopPropagation?e.stopPropagation():void 0!==e.cancelBubble&&e.cancelBubble!==!0&&(e.cancelBubble=!0),E.onCloseClick&&E.onCloseClick(e),b(!0)}),E.onclick&&I.click(function(e){E.onclick(e),b()})}function r(){I.hide(),I[E.showMethod]({duration:E.showDuration,easing:E.showEasing,complete:E.onShown}),E.timeOut>0&&(k=setTimeout(b,E.timeOut),F.maxHideTime=parseFloat(E.timeOut),F.hideEta=(new Date).getTime()+F.maxHideTime,E.progressBar&&(F.intervalId=setInterval(x,10)))}function c(){t.iconClass&&I.addClass(E.toastClass).addClass(y)}function l(){E.newestOnTop?v.prepend(I):v.append(I)}function u(){if(t.title){var e=t.title;E.escapeHtml&&(e=o(t.title)),M.append(e).addClass(E.titleClass),I.append(M)}}function d(){if(t.message){var e=t.message;E.escapeHtml&&(e=o(t.message)),B.append(e).addClass(E.messageClass),I.append(B)}}function p(){E.closeButton&&(j.addClass(E.closeClass).attr("role","button"),I.prepend(j))}function g(){E.progressBar&&(q.addClass(E.progressClass),I.prepend(q))}function C(){E.rtl&&I.addClass("rtl")}function O(e,t){if(e.preventDuplicates){if(t.message===w)return!0;w=t.message}return!1}function b(t){var n=t&&E.closeMethod!==!1?E.closeMethod:E.hideMethod,o=t&&E.closeDuration!==!1?E.closeDuration:E.hideDuration,s=t&&E.closeEasing!==!1?E.closeEasing:E.hideEasing;if(!e(":focus",I).length||t)return clearTimeout(F.intervalId),I[n]({duration:o,easing:s,complete:function(){h(I),clearTimeout(k),E.onHidden&&"hidden"!==P.state&&E.onHidden(),P.state="hidden",P.endTime=new Date,f(P)}})}function D(){(E.timeOut>0||E.extendedTimeOut>0)&&(k=setTimeout(b,E.extendedTimeOut),F.maxHideTime=parseFloat(E.extendedTimeOut),F.hideEta=(new Date).getTime()+F.maxHideTime)}function H(){clearTimeout(k),F.hideEta=0,I.stop(!0,!0)[E.showMethod]({duration:E.showDuration,easing:E.showEasing})}function x(){var e=(F.hideEta-(new Date).getTime())/F.maxHideTime*100;q.width(e+"%")}var E=m(),y=t.iconClass||E.iconClass;if("undefined"!=typeof t.optionsOverride&&(E=e.extend(E,t.optionsOverride),y=t.optionsOverride.iconClass||y),!O(E,t)){T++,v=n(E,!0);var k=null,I=e("<div/>"),M=e("<div/>"),B=e("<div/>"),q=e("<div/>"),j=e(E.closeHtml),F={intervalId:null,hideEta:null,maxHideTime:null},P={toastId:T,state:"visible",startTime:new Date,options:E,map:t};return s(),r(),a(),f(P),E.debug&&console&&console.log(P),I}}function m(){return e.extend({},p(),b.options)}function h(e){v||(v=n()),e.is(":visible")||(e.remove(),e=null,0===v.children().length&&(v.remove(),w=void 0))}var v,C,w,T=0,O={error:"error",info:"info",success:"success",warning:"warning"},b={clear:r,remove:c,error:t,getContainer:n,info:o,options:{},subscribe:s,success:i,version:"2.1.3",warning:a};return b}()})}("function"==typeof define&&define.amd?define:function(e,t){"undefined"!=typeof module&&module.exports?module.exports=t(require("jquery")):window.toastr=t(window.jQuery)});
//# sourceMappingURL=toastr.js.map
/*toastr options*/
toastr.options.preventDuplicates = true;

var Action = {};
(function(action) {
    action.json = {};
    action.actionTypeChange = function() {
        var actionType = $("#ActionType").val();
        var json = "";
        switch (actionType) {
            case "Email":
            action.initEdit("");
            $("#KeywordsBtnWrap").addClass("hidden");
            $("#WebRequestWrap").addClass("hidden");
            $("#ContentWrap").removeClass("hidden");
            $("#SubjectWrap").removeClass("hidden");
            break;
            case "WebRequest":
            tinymce.remove();
            $("#WebRequestWrap").removeClass("hidden");
            $("#SubjectWrap").addClass("hidden");
            $("#ContentWrap").addClass("hidden");
            break;
        }
        $("#Content").val(json);
    };
    action.initEdit = function (value) {
            tinymce.remove();
            
            $("#Content").html(value);
            $("#SubjectWrap").removeClass("hidden");
            tinymce.init({
                selector: "#Content",
                height: 300,
                menubar: false,
                plugins: [
                    "advlist autolink lists link image charmap print preview anchor",
                    "searchreplace visualblocks code fullscreen",
                    "insertdatetime media table contextmenu paste code"
                ],
                toolbar:
                    "undo redo | insert | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image | addKeyword",
                setup: function(editor) {
                    editor.addButton("addKeyword",
                    {
                        type: "listbox",
                        text: "Add",
                        icon: false,
                        onselect: function(e) {
                            editor.insertContent(this.value());
                        },
                        values: [
                            { text: "Action Date", value: "[ActionDate]" },
                            { text: "Sensor Name", value: "[SensorName]" },
                            { text: "Sensor Value", value: "[SensorValue]" }
                        ],

                    });
                },
            });
        
    };

    action.addContent = function(value) {
        $("#Content").val($("#Content").val() + value);
    };
    action.addHeader = function() {
        var index = $("#HeadersWrap .panel-body input.header-name").length;
        var html = '<div id="row-' +
            index +
            '"><div class="form-group col-md-5">' +
            '<label class="control-label" > Name</label>' +
            '<input type="text" name="headername[' +
            index +
            ']" class="header-name form-control" />' +
            "</div>" +
            '<div class="form-group col-md-5">' +
            '<label class="control-label">Value</label>' +
            '<input type="text" name="headervalue[' +
            index +
            ']" class="header-value form-control" />' +
            "</div>" +
            '<div class="col-md-2 text-align-center" style="margin-top: 35px;">' +
            '<a class="text-danger" onclick="Action.deleteHeader(' +
            index +
            ')">' +
            '<i class="fa fa-minus"></i>' +
            "</a>" +
            "</div> </div>";
        $("#HeadersWrap .panel-body").append(html);
    };
    action.deleteHeader = function(index) {
        var total = $("#HeadersWrap .panel-body input.header-name").length;
        $("#row-" + index).remove();
        for (var i = index + 1; i < total; i++) {
            var $row = $("#row-" + i);
            $row.attr("id", "row-" + (i - 1));
            $("input", $row).each(function(i1, e1) {
                var $input = $(e1);
                if ($input.hasClass("header-name") == true) {
                    $input.attr("name", "headername[" + (i - 1) + "]");
                } else {
                    $input.attr("name", "headervalue[" + (i - 1) + "]");
                }
            });
        }
    };

    action.beforeSave = function () {      
        var actionType = $("#ActionType").val();
        if (actionType=="WebRequest") {
            var content = {};
            content.Method = $("select[name=Method]").val();
            content.Body = treema.data;
            content.Headers = [];
            $("#HeadersWrap .panel-body div[id^=row-]").each(function(i, e) {
                var name = $("input.header-name", e).val();
                if (name != "") {
                    var value = $("input.header-value", e).val();
                    content.Headers.push({ "Name": name, "Value": value });
                }
            });
            content.Url = $("input[name=Url]").val();
            content.Security = {};
            content.Security.Type = $("select[name=Type]").val();
            content.Security.Username = $("input[name=Username]").val();
            content.Security.Password = $("input[name=Password]").val();
            $("#Content").val(JSON.stringify(content));     
        }
        else {
            
            var content={};
            content.Subject=$("#Subject").val();
            content.Body=tinymce.activeEditor.getContent();
            content.To=$("#To").val();
            $("#Content").val(JSON.stringify(content));
            $("#To").val(""); 
            $("#Subject").val("");    
        }
        $("#action-modal").modal("toggle");
        var ruleId=$("#action-ruleId").val();
        var $rule=$("#rule-"+ruleId);
        var $actions=$("#actions-"+ruleId);
        if($actions.length==0){
            $rule.after("<tr id='actions-"+ruleId+"'><td colspan='4'><table class='table'><thead><th colspan='3'>Actions</th></thead><thead><th>Name</th><th>Type</th><th>Content</th></thead></table></td></tr>");
            $actions=$("#actions-"+ruleId);
        }
        var $actionsTable=$("table",$actions);

        var $actionName=$("#ActionName");

        $actionsTable.append("<tr><td>"+$actionName.val()+"</td><td>"+$("#ActionType").val()+"</td><td>"+$("#Content").val()+"</td></tr>");
        $("#Content").val("");
        $("#ActionName").val("");  
        treema.data={};
        $("#Url").val(""); 
        $("input[name=Username]").val("");
        $("input[name=Password]").val("");
       $("#HeadersWrap .panel-body div[id^=row-]").each(function(i, e) {
            if(i>0){
                $("input.header-name", e).remove();
                $("input.header-value", e).remove();
            }
            else{
                $("input.header-name", e).val("");
                $("input.header-value", e).val("");
            }
        });
    };

})(Action);


var Sensor={};
var ruleCount=0;

(function(sensor){
    sensor.addRule=function(){
        var ruleName=$("#rule-name").val();
        var ruleOperation=$("#rule-operation").val();
        var ruleValue=$("#rule-value").val();
        var $form=$("#sensor-create-form");
        $form.append("<input type='hidden' name='Rules["+ruleCount+"].Name' value='"+ruleName+"' />");
        $form.append("<input type='hidden' name='Rules["+ruleCount+"].Operation' value='"+ruleOperation+"' />");
        $form.append("<input type='hidden' name='Rules["+ruleCount+"].Value' value='"+ruleValue+"' />");
        var html="<tr id='rule-"+ruleCount+"'>";
        html+="<td>"+ruleName+"</td>";
        html+="<td>"+$("#rule-operation option:selected").text()+"</td>";
        html+="<td>"+ruleValue+"</td>";
        html+="<td class='text-center'><a onclick='Sensor.deleteRule("+ruleCount+");' class='btn btn-sm'><i class='glyphicon glyphicon-remove text-danger'></i></a> <a onclick='Sensor.addAction("+ruleCount+");' class='btn btn-sm'><i class='glyphicon glyphicon-plus text-success'></i></a></td>";
        html+="</tr>";
        $("#rules table tbody").append(html);
        ruleCount++;       
    };
    sensor.deleteRule=function(ruleId){
        $("#rule-"+ruleId).remove();
        $("input[name^='Rules["+ruleId+"]']").remove();
         $("#actions-"+ruleId).remove();
    };

    sensor.addAction=function(ruleId){
        $("#action-ruleId").val(ruleId);
        Action.actionTypeChange();
        $("#action-modal").modal();
    };


})(Sensor);

