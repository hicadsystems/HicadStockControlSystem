#pragma checksum "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\ReceiptAnalysis\AnalysisPdf.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2afd32bc43ec7cfa5c64e3fde76aee88b6761697"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ReceiptAnalysis_AnalysisPdf), @"mvc.1.0.view", @"/Views/ReceiptAnalysis/AnalysisPdf.cshtml")]
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
#line 2 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\_ViewImports.cshtml"
using HicadStockSystem.UI.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\ReceiptAnalysis\AnalysisPdf.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2afd32bc43ec7cfa5c64e3fde76aee88b6761697", @"/Views/ReceiptAnalysis/AnalysisPdf.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"394b8959b6ec18d000bb128a2c1c9d18515154c1", @"/Views/_ViewImports.cshtml")]
    public class Views_ReceiptAnalysis_AnalysisPdf : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HicadStockSystem.Core.Utilities.ReportVM>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\ReceiptAnalysis\AnalysisPdf.cshtml"
  
	ViewBag.Title = "AnalysisPdf";

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\ReceiptAnalysis\AnalysisPdf.cshtml"
  
	Layout = null;


#line default
#line hidden
#nullable disable
            WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2afd32bc43ec7cfa5c64e3fde76aee88b67616974269", async() => {
                WriteLiteral("\r\n\t <h1 style=\"text-align:center\" class=\"text-center display-4\">");
#nullable restore
#line 13 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\ReceiptAnalysis\AnalysisPdf.cshtml"
                                                            Write(Model.StkSystems.CompanyName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h1>\r\n\t <h3 style=\"text-align:center\">");
#nullable restore
#line 14 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\ReceiptAnalysis\AnalysisPdf.cshtml"
                              Write(Model.StkSystems.CompanyAddress);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h3>\r\n\r\n\t <br />\r\n");
                WriteLiteral("\r\n\t <h3>Stock Position Report: Produce On ");
#nullable restore
#line 20 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\ReceiptAnalysis\AnalysisPdf.cshtml"
                                      Write(DateTime.Now);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</h3>
	 <table border=""2"" cellpadding=""2"" cellspacing=""0"" width=""100%"">
		  <tr style=""text-align:center"">
				<th>Supplier Code</th>
				<th>Name</th>
				<th>Document No.</th>
				<th>Date</th>
				<th>Item Descrption</th>
				<th>Quantity</th>
				<th>Price</th>
				<th>Amount</th>
		  </tr>
");
#nullable restore
#line 32 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\ReceiptAnalysis\AnalysisPdf.cshtml"
             foreach (var a in Model.Receipts)
			{

#line default
#line hidden
#nullable disable
                WriteLiteral("\t\t\t\t<tr style=\"text-align:center\">\r\n\t\t\t\t\t<td> ");
#nullable restore
#line 35 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\ReceiptAnalysis\AnalysisPdf.cshtml"
                    Write(a.SupplierCode);

#line default
#line hidden
#nullable disable
                WriteLiteral(" </td>\r\n\t\t\t\t\t<td> ");
#nullable restore
#line 36 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\ReceiptAnalysis\AnalysisPdf.cshtml"
                    Write(a.SupplierName);

#line default
#line hidden
#nullable disable
                WriteLiteral(" </td>\r\n\t\t\t\t\t<td> ");
#nullable restore
#line 37 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\ReceiptAnalysis\AnalysisPdf.cshtml"
                    Write(a.DocNo);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n\t\t\t\t\t<td> ");
#nullable restore
#line 38 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\ReceiptAnalysis\AnalysisPdf.cshtml"
                    Write(a.Date.ToString());

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n\t\t\t\t\t<td> ");
#nullable restore
#line 39 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\ReceiptAnalysis\AnalysisPdf.cshtml"
                    Write(a.ItemDescription);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n\t\t\t\t\t<td> ");
#nullable restore
#line 40 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\ReceiptAnalysis\AnalysisPdf.cshtml"
                    Write(a.Quantity);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n\t\t\t\t\t<td>");
#nullable restore
#line 41 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\ReceiptAnalysis\AnalysisPdf.cshtml"
                   Write(Math.Round((decimal)(a.Price),2));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n\t\t\t\t\t<td>");
#nullable restore
#line 42 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\ReceiptAnalysis\AnalysisPdf.cshtml"
                   Write(Math.Round((decimal)(a.Amount),2));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n\t\t\t\t</tr>\r\n");
#nullable restore
#line 44 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\ReceiptAnalysis\AnalysisPdf.cshtml"


			}

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\t\t  <tr>\r\n\t\t\t   <td><span><b>Total</b></span></td><td></td><td></td><td></td>\r\n\t\t\t\t<td></td>\r\n\t\t\t\t<td></td>\r\n\t\t\t\t<td></td>\r\n\t\t\t\t<td style=\"text-align:center\"><span><b>");
#nullable restore
#line 53 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\ReceiptAnalysis\AnalysisPdf.cshtml"
                                                  Write(Math.Round((decimal)Model.Receipts.ToList().Sum(x=>x.Amount),2));

#line default
#line hidden
#nullable disable
                WriteLiteral("</b></span></td>\r\n\t\t  </tr>\r\n\r\n\t </table>\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HicadStockSystem.Core.Utilities.ReportVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
