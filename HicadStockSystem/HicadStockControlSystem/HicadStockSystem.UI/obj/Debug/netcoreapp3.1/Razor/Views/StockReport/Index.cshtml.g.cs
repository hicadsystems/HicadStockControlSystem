#pragma checksum "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\StockReport\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "799d320590ab14f3b02b25af95d267ae0f6349d8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_StockReport_Index), @"mvc.1.0.view", @"/Views/StockReport/Index.cshtml")]
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
#line 1 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\_ViewImports.cshtml"
using HicadStockSystem.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\StockReport\Index.cshtml"
using HicadStockSystem.Core.Utilities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\StockReport\Index.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\StockReport\Index.cshtml"
using HicadStockSystem.UI.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"799d320590ab14f3b02b25af95d267ae0f6349d8", @"/Views/StockReport/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"394b8959b6ec18d000bb128a2c1c9d18515154c1", @"/Views/_ViewImports.cshtml")]
    public class Views_StockReport_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ReportVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "StockReport", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "PrintStockPosition", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 5 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\StockReport\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n<div class=\"row\">\r\n\t <div class=\"col-md-12 grid-margin\">\r\n\t\t  <div class=\"card\">\r\n\t\t\t   <div class=\"card-body\">\r\n\r\n\t\t\t\t\t<h1 style=\"text-align:center\" class=\"text-center display-4\">");
#nullable restore
#line 18 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\StockReport\Index.cshtml"
                                                                           Write(Model.StkSystems.CompanyName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\t\t\t\t\t<h3 style=\"text-align:center\">");
#nullable restore
#line 19 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\StockReport\Index.cshtml"
                                             Write(Model.StkSystems.CompanyAddress);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n \r\n\t\t\t\t\t<br />\r\n\t\t\t\t\t<h3 style=\"text-align:center\">REPORTS</h3>\r\n\t\t\t\t\t<h4 style=\"text-align:center\">Stock Position</h4>\r\n\t\t\t\t\t<br /><br />\r\n\t\t\t\t\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "799d320590ab14f3b02b25af95d267ae0f6349d86374", async() => {
                WriteLiteral("print");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
					<div class=""row"">
						 <table class=""table table-striped"" style=""text-align:center"">
							  <tr  style=""text-align:center"">
							   <th>Item Code</th>
							   <th>Item Desc</th>
							   <th>PartNo</th>
							   <th>Current Quantity</th>
							   <th>Price</th>
							   <th>Value</th>
");
            WriteLiteral("\t\t\t\t\t\t\t  </tr>\r\n");
#nullable restore
#line 37 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\StockReport\Index.cshtml"
                                 foreach (var a in Model.StockPosition)
								{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t<tr style=\"text-align:center\">\r\n\t\t\t\t\t\t\t\t   <td> ");
#nullable restore
#line 40 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\StockReport\Index.cshtml"
                                   Write(a.ItemCode);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n\t\t\t\t\t\t\t\t   <td> ");
#nullable restore
#line 41 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\StockReport\Index.cshtml"
                                   Write(a.ItemDesc);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n\t\t\t\t\t\t\t\t   <td> ");
#nullable restore
#line 42 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\StockReport\Index.cshtml"
                                   Write(a.PartNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t\t\t\t\t   <td> ");
#nullable restore
#line 43 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\StockReport\Index.cshtml"
                                   Write(a.CurrentBalance);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t\t\t\t\t   <td> ");
#nullable restore
#line 44 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\StockReport\Index.cshtml"
                                   Write(Math.Round((decimal)(a.Price),2));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n\t\t\t\t\t\t\t\t   <td> ");
#nullable restore
#line 45 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\StockReport\Index.cshtml"
                                   Write(Math.Round((decimal)(a.Value),2));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n\t\t\t\t\t\t\t\t  </tr>\r\n");
#nullable restore
#line 47 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\StockReport\Index.cshtml"


								}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t  <tr>\t\r\n\t\t\t\t\t\t\t\t\t<td><span><b>Total</b></span></td><td></td><td></td><td></td>\r\n\t\t\t\t\t\t\t\t\t<td></td>\r\n\t\t\t\t\t\t\t\t\t<td style=\"text-align:center\"><span><b>");
#nullable restore
#line 53 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\StockReport\Index.cshtml"
                                                                      Write(Math.Round((decimal)Model.StockPosition.ToList().Sum(x=>x.Value),2));

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></span></td>\r\n\t\t\t\t\t\t\t </tr>\r\n\t\t\t\t\t\t </table> <br />\r\n\t\t\t\t\t\t\r\n\t \r\n\t\t\t\t\t</div>\r\n\r\n");
            WriteLiteral("\t\t\t   </div>\r\n\t\t  </div>\r\n\t </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ReportVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
