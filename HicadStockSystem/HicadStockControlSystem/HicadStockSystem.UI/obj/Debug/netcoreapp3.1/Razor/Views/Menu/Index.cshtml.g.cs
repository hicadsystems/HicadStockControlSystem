#pragma checksum "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\Menu\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d52c585466d1990cd5913f1b3f5cf7d5e1bd5a8c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Menu_Index), @"mvc.1.0.view", @"/Views/Menu/Index.cshtml")]
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
#line 1 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\Menu\Index.cshtml"
using HicadStockSystem.Controllers.ResourcesVM.AcountVM;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d52c585466d1990cd5913f1b3f5cf7d5e1bd5a8c", @"/Views/Menu/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"394b8959b6ec18d000bb128a2c1c9d18515154c1", @"/Views/_ViewImports.cshtml")]
    public class Views_Menu_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MenusViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/menu/update"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("post-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\Menu\Index.cshtml"
  
    ViewData["Title"] = "Menus";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"


<div class=""card"">
    <div class=""card-header"">
        Menus
    </div>
    <div class=""card-body"">
        <div class=""row"">
            <div style=""display:none"" class=""col-3 offset-9"">
                <button class='btn btn-success btn-block' id=""add-edit"" data-toggle=""modal"" data-target=""#menuModal"">
                    <i class=""fa fa-plus""></i> &nbsp; Add Menu
                </button>
            </div>
            <hr class=""btn-block"">
        </div>
        <div class=""row"">
            <div class=""col-sm-12"">
                <table id=""data-table"" class=""table table-striped table-bordered"">
                    <thead>
                        <tr>
                            <td>Name</td>
                            <td>Status</td>
                            <td></td>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 35 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\Menu\Index.cshtml"
                         foreach (var menu in Model.Menus)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr class=\"e-row\" data-menu-id=\"");
#nullable restore
#line 37 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\Menu\Index.cshtml"
                                                       Write(menu.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                                <td class=\"e-details\" data-menu-id=\"");
#nullable restore
#line 38 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\Menu\Index.cshtml"
                                                               Write(menu.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                                    ");
#nullable restore
#line 39 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\Menu\Index.cshtml"
                               Write(menu.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n");
#nullable restore
#line 41 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\Menu\Index.cshtml"
                                 if (menu.IsActive)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td><span class=\"badge badge-success\"><i class=\"fa fa-check\"></i>&nbsp;Active</span></td>\r\n");
#nullable restore
#line 44 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\Menu\Index.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td><span class=\"badge badge-danger\"><i class=\"fa fa-times\"></i>&nbsp;Inactive</span></td>\r\n");
#nullable restore
#line 48 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\Menu\Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 49 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\Menu\Index.cshtml"
                                 if (menu.IsActive)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td><a type=\"button\" class=\"btn btn-danger\"");
            BeginWriteAttribute("href", " href=\"", 2059, "\"", 2092, 2);
            WriteAttributeValue("", 2066, "menu/ToggleStatus/", 2066, 18, true);
#nullable restore
#line 51 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\Menu\Index.cshtml"
WriteAttributeValue("", 2084, menu.Id, 2084, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Deactivate</a></td>\r\n");
#nullable restore
#line 52 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\Menu\Index.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td><a type=\"button\" class=\"btn btn-primary\"");
            BeginWriteAttribute("href", " href=\"", 2303, "\"", 2336, 2);
            WriteAttributeValue("", 2310, "menu/ToggleStatus/", 2310, 18, true);
#nullable restore
#line 55 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\Menu\Index.cshtml"
WriteAttributeValue("", 2328, menu.Id, 2328, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Activate</a></td>\r\n");
#nullable restore
#line 56 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\Menu\Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </tr>\r\n");
#nullable restore
#line 59 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\Menu\Index.cshtml"

                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </tbody>
                </table>
            </div>
        </div>
    </div>
</div>

<!-- Create Device Modal-->
<div class=""modal fade"" id=""menuModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""vLabel"" aria-hidden=""true""
     data-backdrop=""static"">
    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d52c585466d1990cd5913f1b3f5cf7d5e1bd5a8c12455", async() => {
                WriteLiteral("\r\n        ");
#nullable restore
#line 72 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\Menu\Index.cshtml"
   Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
        <div class=""modal-dialog modal-lg"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h5 class=""modal-title"" id=""menuModalLabel"">Edit Menu</h5>
                    <button type=""button"" class=""close dismiss-modal"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                </div>
                <div class=""modal-body"">
                    <input type=""hidden"" value=""0"" id=""id"" name=""id"" />
                    <div class=""row"">
                        <div class=""form-group col-sm-6"">
                            <label for=""Name"" class=""control-label"">
                                Name
                            </label>
                            <input type=""text"" id=""name"" name=""name"" required class=""form-control"">
                        </div>
                        <div class=""form-group col-sm-6"">
             ");
                WriteLiteral(@"               <label for=""code"" class=""control-label"">
                                Code
                            </label>
                            <input type=""text"" id=""code"" name=""code"" required class=""form-control"">
                        </div>
                    </div>

                    <div class=""form-group"">
                        <label for=""Description"" class=""control-label"">
                            Description
                        </label>
                        <textarea name=""Description"" id=""description"" class=""form-control"" required></textarea>
                    </div>
                    <div class=""row"">
                        <div class=""form-group col-sm-6"">
                            <label for=""controller"" class=""control-label"">
                                Controller
                            </label>
                            <input readonly type=""text"" id=""controller"" name=""controller"" required class=""form-control"">
               ");
                WriteLiteral(@"         </div>
                        <div class=""form-group col-sm-6"">
                            <label for=""action"" class=""control-label"">
                                Action
                            </label>
                            <input readonly type=""text"" id=""action"" name=""action"" required class=""form-control"">
                        </div>
                    </div>

                    <label for=""menus""");
                BeginWriteAttribute("class", " class=\"", 5339, "\"", 5347, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                        Menus Group
                    </label>
                    <div class=""form-group"">
                        <select style=""width:100%"" id=""menugroup"" name=""menugroup"" class=""required form-control row"">
                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d52c585466d1990cd5913f1b3f5cf7d5e1bd5a8c16117", async() => {
                    WriteLiteral("Select Menus");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 125 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\Menu\Index.cshtml"
                             foreach (var menugroups in Model.MenuGroups)
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d52c585466d1990cd5913f1b3f5cf7d5e1bd5a8c17750", async() => {
#nullable restore
#line 127 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\Menu\Index.cshtml"
                                                          Write(menugroups.Name);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 127 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\Menu\Index.cshtml"
                                   WriteLiteral(menugroups.Id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 128 "E:\ProjectsTom\HicadStockControlSystem\HicadStockControlSystem\HicadStockSystem\HicadStockControlSystem\HicadStockSystem.UI\Views\Menu\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                        </select>
                    </div>
                    <div>
                        <label for=""active"" class=""control-label"">
                            Active
                        </label>
                        <label class=""switch switch-default switch-pill switch-secondary mr-2"">
                            <input name=""Active"" type=""checkbox"" class=""switch-input"" value=""true"" checked=""true"">
                            <span class=""switch-label""></span>
                            <span class=""switch-handle""></span>
                        </label>
                    </div>

                    <div class=""modal-footer"">
                        <button type=""button"" class=""btn btn-secondary dismiss-modal"" data-dismiss=""modal"">Cancel</button>
                        <button type=""submit"" class=""btn btn-success"" id=""addDevice"">Save</button>
                    </div>

                </div>
            </div>
        </div>
    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
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
<!-- End Create menu Modal-->


<script>
    $(document).ready(function () {
        $('#data-table').DataTable({
            ""language "": {
                ""emptyTable "": ""No Menus. Add new Menu. ""
            }
        });

        $(""#menugroup"").select2();

        $('#data-table tbody').on('click', '.e-details', function () {

            menuId = $(this).data('menu-id')

            var url = window.location.origin + '/menu/' + menuId;
            $.get(url, function (response) {
                if (response.success) {
                    $(""#id"").val(response.data.menu.id)
                    $(""#name"").val(response.data.menu.name);
                    $(""#code"").attr(""readonly"", ""readonly"")
                    $(""#code"").val(response.data.menu.code);
                    $(""#description"").val(response.data.menu.description)
                    $(""#controller"").val(response.data.menu.controller)
                    $(""#action"").val(response.data.menu.action)
        ");
            WriteLiteral(@"            $(""#add-edit"").trigger(""click"")

                    if (response.data.menu.menuGroupId) {
                        $(""#menugroup"").val(response.data.menu.menuGroupId).trigger('change')
                    }

                }

            });
        });

    });
</script>

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MenusViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
