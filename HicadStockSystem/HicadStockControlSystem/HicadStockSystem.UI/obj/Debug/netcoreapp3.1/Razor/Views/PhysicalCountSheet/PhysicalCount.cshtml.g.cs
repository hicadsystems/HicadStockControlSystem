#pragma checksum "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\PhysicalCountSheet\PhysicalCount.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7717e45c0f69e768f97fc03b711ac8f8c2f8d239"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PhysicalCountSheet_PhysicalCount), @"mvc.1.0.view", @"/Views/PhysicalCountSheet/PhysicalCount.cshtml")]
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
#line 2 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\PhysicalCountSheet\PhysicalCount.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7717e45c0f69e768f97fc03b711ac8f8c2f8d239", @"/Views/PhysicalCountSheet/PhysicalCount.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"394b8959b6ec18d000bb128a2c1c9d18515154c1", @"/Views/_ViewImports.cshtml")]
    public class Views_PhysicalCountSheet_PhysicalCount : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HicadStockSystem.Core.Utilities.ReportVM>
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
#line 3 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\PhysicalCountSheet\PhysicalCount.cshtml"
  
	ViewBag.Title = "PrintSearchReport";

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\PhysicalCountSheet\PhysicalCount.cshtml"
  
	Layout = null;
	


#line default
#line hidden
#nullable disable
            WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7717e45c0f69e768f97fc03b711ac8f8c2f8d2394318", async() => {
                WriteLiteral("\r\n\t <h1 style=\"text-align:center\" class=\"text-center display-4\">");
#nullable restore
#line 14 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\PhysicalCountSheet\PhysicalCount.cshtml"
                                                            Write(Model.StkSystems.CompanyName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h1>\r\n\t <h3 style=\"text-align:center\">");
#nullable restore
#line 15 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\PhysicalCountSheet\PhysicalCount.cshtml"
                              Write(Model.StkSystems.CompanyAddress);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h3>\r\n\t <br />\r\n\t <h3>Physical Count Sheets: Produce On ");
#nullable restore
#line 17 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\PhysicalCountSheet\PhysicalCount.cshtml"
                                      Write(DateTime.Now);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h3>\r\n\t <br />\r\n\t <table border=\"2\" cellpadding=\"1\" cellspacing=\"0\" width=\"100%\">\r\n\t\t  <tr style=\"text-align:center\">\r\n\t\t\t   <th>Item Code</th>\r\n\t\t\t   <th>Item Description</th>\r\n\t\t\t   <th>Location</th>\r\n\t\t\t   <th>Quantity</th>\r\n\t\t  </tr>\r\n");
#nullable restore
#line 26 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\PhysicalCountSheet\PhysicalCount.cshtml"
             foreach (var a in Model.PhysicalCountSheets)
			{

#line default
#line hidden
#nullable disable
                WriteLiteral("\t\t\t  <tr style=\"text-align:center\">\r\n\t\t\t   <td> ");
#nullable restore
#line 29 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\PhysicalCountSheet\PhysicalCount.cshtml"
               Write(a.ItemCode);

#line default
#line hidden
#nullable disable
                WriteLiteral(" </td>\r\n\t\t\t   <td> ");
#nullable restore
#line 30 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\PhysicalCountSheet\PhysicalCount.cshtml"
               Write(a.ItemDesc);

#line default
#line hidden
#nullable disable
                WriteLiteral(" </td>\r\n\t\t\t   <td> ");
#nullable restore
#line 31 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\PhysicalCountSheet\PhysicalCount.cshtml"
               Write(a.Location);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n\t\t\t   <td></td>\r\n\t\t\t  </tr>\r\n");
#nullable restore
#line 34 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\PhysicalCountSheet\PhysicalCount.cshtml"
			}

#line default
#line hidden
#nullable disable
                WriteLiteral("\t </table>\r\n");
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