#pragma checksum "C:\Users\PC\Documents\Zalo Received Files\FPT_SEM4\Admin_WebRuou\Views\KhachHang\ThongkeSPBanra.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7ebf211b1b3da2a10f5cde55cce43062f785ad5f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_KhachHang_ThongkeSPBanra), @"mvc.1.0.view", @"/Views/KhachHang/ThongkeSPBanra.cshtml")]
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
#line 1 "C:\Users\PC\Documents\Zalo Received Files\FPT_SEM4\Admin_WebRuou\Views\_ViewImports.cshtml"
using Admin_WebRuou;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\PC\Documents\Zalo Received Files\FPT_SEM4\Admin_WebRuou\Views\_ViewImports.cshtml"
using Admin_WebRuou.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7ebf211b1b3da2a10f5cde55cce43062f785ad5f", @"/Views/KhachHang/ThongkeSPBanra.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"40f464a52257a642139fbd1dc5d015176144ff9f", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_KhachHang_ThongkeSPBanra : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Admin_WebRuou.Models.DetailsDonHang>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ThongkeSPBanra", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "KhachHang", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", new global::Microsoft.AspNetCore.Html.HtmlString("form1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\PC\Documents\Zalo Received Files\FPT_SEM4\Admin_WebRuou\Views\KhachHang\ThongkeSPBanra.cshtml"
  
    ViewData["Title"] = "ThongkeSPBanra";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""container"">
    <div class=""row"">
        <div class=""col-lg-12"">
            <div class=""page-content"">
                <div class=""gaming-library"">
                    <div class=""col-lg-12"">
                        <center>
                            <div class=""heading-section"">
                                <a style=""color:#ec6090 ; font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size:25px"">List Number of products sold</a>
                                <p><a style=""color:white ; font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size:18px"">");
#nullable restore
#line 15 "C:\Users\PC\Documents\Zalo Received Files\FPT_SEM4\Admin_WebRuou\Views\KhachHang\ThongkeSPBanra.cshtml"
                                                                                                                                   Write(ViewBag.ngaybc);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></p>\r\n                            </div>\r\n                            <br />\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7ebf211b1b3da2a10f5cde55cce43062f785ad5f6399", async() => {
                WriteLiteral(@"
                                <div>
                                    <a style=""color:white ; font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size:16px"">From</a>
                                    <input type=""date"" name=""tungay"" style=""color:black ; font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size:16px"" />
                                    <a style=""color:white ; font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size:16px"">To</a>
                                    <input type=""date"" name=""denngay"" style=""color:black ; font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size:16px"" />
                                    <input type=""submit"" value=""Search"" class=""btn btn-info btn-sm"" style=""font-size:14px"" />
                                </div>
                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                            <br />
                        </center>
                        <table width=""100%"" cellpadding=""5"" align=""center"">
                            <tr style=""background-color:gray"">
                                <th>
                                    <div>
                                        <ul>
                                            <li><a style=""color:white ; font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size:16px"">Numerical order</a></li>
                                        </ul>
                                    </div>
                                </th>
                                <th>
                                    <div>
                                        <ul>
                                            <li><a style=""color:white ; font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size:16px"">Product's name</a></li>
                                        </ul>
                              ");
            WriteLiteral(@"      </div>
                                </th>
                                <th>
                                    <div>
                                        <ul>
                                            <li><a style=""color:white ; font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size:16px"">Sales number</a></li>
                                        </ul>
                                    </div>
                                </th>
                                <th>
                                    <div>
                                        <ul>
                                            <li><a style=""color:white ; font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size:16px"">Unit price</a></li>
                                        </ul>
                                    </div>
                                </th>
                                <th>
                                    <div>
                                  ");
            WriteLiteral(@"      <ui>
                                            <li><a style=""color:white ; font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size:16px"">Into money</a></li>
                                        </ui>
                                    </div>
                                </th>
                            </tr>
");
#nullable restore
#line 67 "C:\Users\PC\Documents\Zalo Received Files\FPT_SEM4\Admin_WebRuou\Views\KhachHang\ThongkeSPBanra.cshtml"
                             if (true)
                            {
                                int dem = 0;
                                foreach (var item in Model)
                                {
                                    dem++;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                    <tr>
                                        <td align=""center"">
                                            <div>
                                                <ui>
                                                    <li><a style=""color:white ; font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size:14px"">");
#nullable restore
#line 77 "C:\Users\PC\Documents\Zalo Received Files\FPT_SEM4\Admin_WebRuou\Views\KhachHang\ThongkeSPBanra.cshtml"
                                                                                                                                                        Write(dem);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</a></li>
                                                </ui>
                                            </div>
                                        </td>
                                        <td>
                                            <div>
                                                <ui>
                                                    <li><a style=""color:white ; font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size:14px"">");
#nullable restore
#line 84 "C:\Users\PC\Documents\Zalo Received Files\FPT_SEM4\Admin_WebRuou\Views\KhachHang\ThongkeSPBanra.cshtml"
                                                                                                                                                        Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</a></li>
                                                </ui>
                                            </div>
                                        </td>
                                        <td>
                                            <div>
                                                <ui>
                                                    <li><a style=""color:white ; font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size:14px"">");
#nullable restore
#line 91 "C:\Users\PC\Documents\Zalo Received Files\FPT_SEM4\Admin_WebRuou\Views\KhachHang\ThongkeSPBanra.cshtml"
                                                                                                                                                        Write(item.SoLuong.ToString("N").Substring(0,@item.SoLuong.ToString("N").Length-3));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</a></li>
                                                </ui>
                                            </div>
                                        </td>
                                        <td>
                                            <div>
                                                <ui>
                                                    <li><a style=""color:white ; font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size:14px"">");
#nullable restore
#line 98 "C:\Users\PC\Documents\Zalo Received Files\FPT_SEM4\Admin_WebRuou\Views\KhachHang\ThongkeSPBanra.cshtml"
                                                                                                                                                        Write(item.GiaTien.ToString("N").Substring(0,@item.GiaTien.ToString("N").Length-3));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</a></li>
                                                </ui>
                                            </div>
                                        </td>
                                        <td>
                                            <div>
                                                <ul>
                                                    <li><a style=""color:white ; font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size:14px"">");
#nullable restore
#line 105 "C:\Users\PC\Documents\Zalo Received Files\FPT_SEM4\Admin_WebRuou\Views\KhachHang\ThongkeSPBanra.cshtml"
                                                                                                                                                        Write(item.ThanhTien.ToString("N").Substring(0,@item.ThanhTien.ToString("N").Length-3));

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n                                                </ul>\r\n                                            </div>\r\n                                        </td>\r\n                                    </tr>\r\n");
#nullable restore
#line 110 "C:\Users\PC\Documents\Zalo Received Files\FPT_SEM4\Admin_WebRuou\Views\KhachHang\ThongkeSPBanra.cshtml"
                                }
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            <tr>
                                <td colspan=""3"">
                                </td>
                                <td>
                                    <div>
                                        <ul>
                                            <li><a style=""color:#ec6090 ; font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size:14px"">Total</a></li>
                                        </ul>
                                    </div>
                                </td>
                                <td>
                                    <div>
                                        <ul>
                                            <li><a style=""color:#ec6090 ; font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size:14px"">");
#nullable restore
#line 125 "C:\Users\PC\Documents\Zalo Received Files\FPT_SEM4\Admin_WebRuou\Views\KhachHang\ThongkeSPBanra.cshtml"
                                                                                                                                                  Write(ViewBag.Tonggiatri);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</a></li>
                                        </ul>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<script language=""JavaScript"">
    //form1.tungay.value = """);
#nullable restore
#line 138 "C:\Users\PC\Documents\Zalo Received Files\FPT_SEM4\Admin_WebRuou\Views\KhachHang\ThongkeSPBanra.cshtml"
                       Write(ViewBag.tungay);

#line default
#line hidden
#nullable disable
            WriteLiteral("\";\r\n    //form1.denngay.value = \"");
#nullable restore
#line 139 "C:\Users\PC\Documents\Zalo Received Files\FPT_SEM4\Admin_WebRuou\Views\KhachHang\ThongkeSPBanra.cshtml"
                        Write(ViewBag.denngay);

#line default
#line hidden
#nullable disable
            WriteLiteral("\";\r\n</script>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 142 "C:\Users\PC\Documents\Zalo Received Files\FPT_SEM4\Admin_WebRuou\Views\KhachHang\ThongkeSPBanra.cshtml"
      
        await Html.RenderPartialAsync("_ValidationScriptsPartial");
    

#line default
#line hidden
#nullable disable
            }
            );
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Admin_WebRuou.Models.DetailsDonHang>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
