#pragma checksum "C:\Users\msier\Documents\Printo\Printo.Intranet\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "26cec381b819e2484e6f5ec410efdfd2ee02336d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\msier\Documents\Printo\Printo.Intranet\Views\_ViewImports.cshtml"
using Printo.Intranet;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\msier\Documents\Printo\Printo.Intranet\Views\_ViewImports.cshtml"
using Printo.Intranet.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"26cec381b819e2484e6f5ec410efdfd2ee02336d", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d6b75bd9aafd7d8524892c9cd47945e1d3f11b4b", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Printo.Data.Data.Order>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Orders", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "ToDoes", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "0", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("selectedOrder"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control myselect"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("saveForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\msier\Documents\Printo\Printo.Intranet\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Printo - zarządzanie zamówieniami";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"row\" style=\"place-content:center; margin-top:10px\">\r\n    <div class=\"col\" style=\"max-width: 260px; min-width:215px\">\r\n        <div class=\"card mb-4 border-success cardCursor\" style=\"text-align:center\"");
            BeginWriteAttribute("onclick", " onclick=\"", 312, "\"", 371, 3);
            WriteAttributeValue("", 322, "location.href=\'", 322, 15, true);
#nullable restore
#line 7 "C:\Users\msier\Documents\Printo\Printo.Intranet\Views\Home\Index.cshtml"
WriteAttributeValue("", 337, Url.Action("Create", "Orders"), 337, 33, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 370, "\'", 370, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n            <div class=\"card-body\" style=\"padding:0.5rem\">\r\n                <div class=\"col\" style=\"padding:0px\">\r\n                    <i class=\"fe fe-plus fe-32\"></i>\r\n                    <br />\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "26cec381b819e2484e6f5ec410efdfd2ee02336d8351", async() => {
                WriteLiteral("\r\n                        <span style=\"font-weight:bold\">Nowe zamówienie</span>\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <div class=\"col\" style=\"max-width: 260px; min-width:215px\">\r\n        <div class=\"card mb-4 border-success cardCursor\" style=\"text-align:center\"");
            BeginWriteAttribute("onclick", " onclick=\"", 989, "\"", 1047, 3);
            WriteAttributeValue("", 999, "location.href=\'", 999, 15, true);
#nullable restore
#line 20 "C:\Users\msier\Documents\Printo\Printo.Intranet\Views\Home\Index.cshtml"
WriteAttributeValue("", 1014, Url.Action("Index", "Orders"), 1014, 32, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1046, "\'", 1046, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n            <div class=\"card-body\" style=\"padding:0.5rem\">\r\n                <div class=\"col\" style=\"padding:0px\">\r\n                    <i class=\"fe fe-monitor fe-32\"></i>\r\n                    <br />\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "26cec381b819e2484e6f5ec410efdfd2ee02336d11097", async() => {
                WriteLiteral("\r\n                        <span style=\"font-weight:bold\">Aktualne zamówienia : </span><span class=\"badge badge-success\" style=\"font-weight:bold;color:white;padding:5px\">");
#nullable restore
#line 26 "C:\Users\msier\Documents\Printo\Printo.Intranet\Views\Home\Index.cshtml"
                                                                                                                                                                  Write(ViewBag.OrdersCount);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <div class=\"col\" style=\"max-width: 260px; min-width:215px\">\r\n        <div class=\"card mb-4 border-success cardCursor\" style=\"text-align:center\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1784, "\"", 1842, 3);
            WriteAttributeValue("", 1794, "location.href=\'", 1794, 15, true);
#nullable restore
#line 33 "C:\Users\msier\Documents\Printo\Printo.Intranet\Views\Home\Index.cshtml"
WriteAttributeValue("", 1809, Url.Action("Index", "ToDoes"), 1809, 32, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1841, "\'", 1841, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n            <div class=\"card-body\" style=\"padding:0.5rem\">\r\n                <div class=\"col\" style=\"padding:0px\">\r\n                    <i class=\"fe fe-alert-circle fe-32\"></i>\r\n                    <br />\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "26cec381b819e2484e6f5ec410efdfd2ee02336d14332", async() => {
                WriteLiteral("\r\n                        <span style=\"font-weight:bold\">Do zrobienia : </span><span class=\"badge badge-success\" style=\"font-weight:bold;color:white;padding:5px\">");
#nullable restore
#line 39 "C:\Users\msier\Documents\Printo\Printo.Intranet\Views\Home\Index.cshtml"
                                                                                                                                                           Write(ViewBag.ToDoesCount);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                </div>
            </div>
        </div>
    </div>
</div>

<div class=""container"" id=""calendar"" style=""padding-bottom:15px; min-height:720px"">
</div>

<div id=""eventModal"" class=""modal fade"" role=""dialog"">
    <div class=""modal-dialog"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h4 class=""modal-title""><span id=""eventTitle""></span></h4>
                <button type=""button"" class=""close"" data-dismiss=""modal"">&times;</button>
            </div>
            <div class=""modal-body"">

                <div class=""col"">
                    <p id=""pDetails""></p>
                </div>

                <div class=""col"">
                    <button id=""btnDelete"" class=""btn btn-outline-danger float-right"">
                        Usuń
                    </button>
                    <button id=""btnEdit"" class=""btn btn-outline-secondary float-right"" style=""margin-right:5px"">
                        Edytuj
                   ");
            WriteLiteral(@" </button>
                    <div id=""DivBtnOrder"">
                        <button id=""btnOrder"" class=""btn btn-outline-success float-right"" style=""margin-right:5px"">
                            Zamówienie
                        </button>
                    </div>
                </div>

            </div>
            <div class=""modal-footer"">
                <div class=""col"">
                    <button id=""btnGray"" class=""btn float-left"" style=""font-size: 50px; padding: 0px; margin: -20px;"">
                        &#9679;
                    </button>
                    <button id=""btnGreen"" class=""btn float-left"" style=""font-size: 50px; padding: 0px; margin: -20px; margin-left:5px; color:#3ad29f"">
                        &#9679;
                    </button>
                    <button id=""btnBlue"" class=""btn float-left"" style=""font-size: 50px; padding: 0px; margin: -20px; margin-left:13px; color:#03A9F4"">
                        &#9679;
                    </button>
           ");
            WriteLiteral(@"         <button id=""btnRed"" class=""btn float-left"" style=""font-size: 50px; padding: 0px; margin: -20px; margin-left:13px; color:#FF5722"">
                        &#9679;
                    </button>
                </div>
                <div class=""col"">
                    <button type=""button"" class=""btn btn-outline-secondary float-right"" data-dismiss=""modal"">Zamknij</button>
                </div>
            </div>
        </div>
    </div>
</div>

<div id=""eventModalSave"" class=""modal fade"" role=""dialog"">
    <div class=""modal-dialog"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h4 class=""modal-title""><span id=""eventTitle"">Nowy blok czasowy</span></h4>
                <button type=""button"" class=""close"" data-dismiss=""modal"">&times;</button>
            </div>
            <div class=""modal-body"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "26cec381b819e2484e6f5ec410efdfd2ee02336d19666", async() => {
                WriteLiteral(@"
                    <input type=""text"" id=""hdEventID"" class=""form-control"" hidden />
                    <div class=""form-group"">
                        <label>Tytuł</label>
                        <input type=""text"" id=""txtTitle"" class=""form-control"" />
                    </div>
                    <div class=""form-group"">
                        <label>Start</label>
                        <div class=""input-group date"">
                            <input type=""text"" id=""txtStart"" class=""form-control"" autocomplete=""off"" />
                        </div>
                    </div>
                    <div class=""form-group"">
                        <div class=""custom-checkbox"">
                            <label>
                                <input type=""checkbox"" id=""chkIsFullDay"" checked=""checked""/><span style=""margin-left:5px"">Wydarzenie całodniowe?</span>
                            </label>
                        </div>
                    </div>
                    <div class=""");
                WriteLiteral(@"form-group"" id=""divEndDate"" style=""display:none"">
                        <label>Koniec</label>
                        <div class=""input-group date"">
                            <input type=""text"" id=""txtEnd"" class=""form-control"" autocomplete=""off"" />
                        </div>
                    </div>
                    <div class=""form-group"">
                        <label>Opis</label>
                        <textarea id=""txtDescription"" rows=""3"" class=""form-control""></textarea>
                    </div>
");
                WriteLiteral("                    <div class=\"form-group\" id=\"divOrder\">\r\n                        <label>Dotyczy zamówienia nr:</label>\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "26cec381b819e2484e6f5ec410efdfd2ee02336d21767", async() => {
                    WriteLiteral("\r\n                            ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "26cec381b819e2484e6f5ec410efdfd2ee02336d22064", async() => {
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                    BeginWriteTagHelperAttribute();
                    __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                    __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                    BeginWriteTagHelperAttribute();
                    __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                    __tagHelperExecutionContext.AddHtmlAttribute("disabled", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_6.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n                        ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
#nullable restore
#line 151 "C:\Users\msier\Documents\Printo\Printo.Intranet\Views\Home\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = ViewBag.OrderID;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 151 "C:\Users\msier\Documents\Printo\Printo.Intranet\Views\Home\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.OrderID);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                    </div>
                    <button form=""saveForm"" type=""button"" id=""btnSave"" class=""btn btn-outline-success float-right"">
                        Zapisz
                    </button>
                    <button type=""button"" class=""btn btn-outline-secondary"" data-dismiss=""modal"">Zamknij</button>
                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Printo.Data.Data.Order> Html { get; private set; }
    }
}
#pragma warning restore 1591
