#pragma checksum "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\St_RequisitionUI\PurgeItem.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9c453a2db2b9d4acf9cae40befa84019d460016c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_St_RequisitionUI_PurgeItem), @"mvc.1.0.view", @"/Views/St_RequisitionUI/PurgeItem.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9c453a2db2b9d4acf9cae40befa84019d460016c", @"/Views/St_RequisitionUI/PurgeItem.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"394b8959b6ec18d000bb128a2c1c9d18515154c1", @"/Views/_ViewImports.cshtml")]
    public class Views_St_RequisitionUI_PurgeItem : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\St_RequisitionUI\PurgeItem.cshtml"
  
    ViewData["Title"] = "PurgeItem";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1");
            BeginWriteAttribute("class", " class=\"", 99, "\"", 107, 0);
            EndWriteAttribute();
            WriteLiteral(">Purge Unissued Requisitions</h1>\r\n<div>\r\n    <purged-item></purged-item>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
