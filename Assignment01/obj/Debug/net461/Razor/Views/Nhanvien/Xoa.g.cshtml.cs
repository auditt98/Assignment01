#pragma checksum "E:\Repos\Assignment01\Assignment01\Views\Nhanvien\Xoa.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f083e71d136b040a4db3a714f16f68240774a9dd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Nhanvien_Xoa), @"mvc.1.0.view", @"/Views/Nhanvien/Xoa.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Nhanvien/Xoa.cshtml", typeof(AspNetCore.Views_Nhanvien_Xoa))]
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
#line 1 "E:\Repos\Assignment01\Assignment01\Views\_ViewImports.cshtml"
using Assignment01;

#line default
#line hidden
#line 2 "E:\Repos\Assignment01\Assignment01\Views\_ViewImports.cshtml"
using Assignment01.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f083e71d136b040a4db3a714f16f68240774a9dd", @"/Views/Nhanvien/Xoa.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7c54143f46862f8ba6a2b7cb07772efe59ecd11f", @"/Views/_ViewImports.cshtml")]
    public class Views_Nhanvien_Xoa : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "E:\Repos\Assignment01\Assignment01\Views\Nhanvien\Xoa.cshtml"
  
    ViewData["Title"] = "Xóa nhân viên";
    var nv = ViewData["thongTinNhanVien"];
    var nvct = ViewData["thongTinNhanVienChiTiet"] as NhanVien;

#line default
#line hidden
            BeginContext(160, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 9 "E:\Repos\Assignment01\Assignment01\Views\Nhanvien\Xoa.cshtml"
  
    Html.RenderPartial("Nav");

#line default
#line hidden
            BeginContext(203, 245, true);
            WriteLiteral("\r\n<div id=\"page-wrapper\">\r\n    <div class=\"row\">\r\n        <div class=\"col-lg-12\">\r\n            <h1 class=\"page-header\">Bạn muốn xóa nhân viên này</h1>\r\n        </div>\r\n    </div>\r\n    <div class=\"row\">\r\n        <div class=\"col-md-6\"><h4>Họ tên: ");
            EndContext();
            BeginContext(449, 10, false);
#line 20 "E:\Repos\Assignment01\Assignment01\Views\Nhanvien\Xoa.cshtml"
                                     Write(nvct.Hoten);

#line default
#line hidden
            EndContext();
            BeginContext(459, 58, true);
            WriteLiteral("</h4></div>\r\n        <div class=\"col-md-6\"><h4>Phòng ban: ");
            EndContext();
            BeginContext(518, 12, false);
#line 21 "E:\Repos\Assignment01\Assignment01\Views\Nhanvien\Xoa.cshtml"
                                        Write(nvct.Tenpban);

#line default
#line hidden
            EndContext();
            BeginContext(530, 58, true);
            WriteLiteral("</h4></div>\r\n        <div class=\"col-md-6\"><h4>Ngày sinh: ");
            EndContext();
            BeginContext(589, 7, false);
#line 22 "E:\Repos\Assignment01\Assignment01\Views\Nhanvien\Xoa.cshtml"
                                        Write(nvct.Ns);

#line default
#line hidden
            EndContext();
            BeginContext(596, 56, true);
            WriteLiteral("</h4></div>\r\n        <div class=\"col-md-6\"><h4>Chức vụ: ");
            EndContext();
            BeginContext(653, 10, false);
#line 23 "E:\Repos\Assignment01\Assignment01\Views\Nhanvien\Xoa.cshtml"
                                      Write(nvct.Tencv);

#line default
#line hidden
            EndContext();
            BeginContext(663, 58, true);
            WriteLiteral("</h4></div>\r\n        <div class=\"col-md-6\"><h4>Giới tính: ");
            EndContext();
            BeginContext(722, 7, false);
#line 24 "E:\Repos\Assignment01\Assignment01\Views\Nhanvien\Xoa.cshtml"
                                        Write(nvct.Gt);

#line default
#line hidden
            EndContext();
            BeginContext(729, 61, true);
            WriteLiteral("</h4></div>\r\n        <div class=\"col-md-6\"><h4>Ngày vào làm: ");
            EndContext();
            BeginContext(791, 15, false);
#line 25 "E:\Repos\Assignment01\Assignment01\Views\Nhanvien\Xoa.cshtml"
                                           Write(nvct.Ngayvaolam);

#line default
#line hidden
            EndContext();
            BeginContext(806, 57, true);
            WriteLiteral("</h4></div>\r\n        <div class=\"col-md-6\"><h4>Quê quán: ");
            EndContext();
            BeginContext(864, 12, false);
#line 26 "E:\Repos\Assignment01\Assignment01\Views\Nhanvien\Xoa.cshtml"
                                       Write(nvct.Tentinh);

#line default
#line hidden
            EndContext();
            BeginContext(876, 62, true);
            WriteLiteral("</h4></div>\r\n        <div class=\"col-md-6\"><h4>Tên đăng nhập: ");
            EndContext();
            BeginContext(939, 13, false);
#line 27 "E:\Repos\Assignment01\Assignment01\Views\Nhanvien\Xoa.cshtml"
                                            Write(nvct.Username);

#line default
#line hidden
            EndContext();
            BeginContext(952, 54, true);
            WriteLiteral("</h4></div>\r\n        <div class=\"col-md-6\"><h4>Email: ");
            EndContext();
            BeginContext(1007, 10, false);
#line 28 "E:\Repos\Assignment01\Assignment01\Views\Nhanvien\Xoa.cshtml"
                                    Write(nvct.Email);

#line default
#line hidden
            EndContext();
            BeginContext(1017, 61, true);
            WriteLiteral("</h4></div>\r\n        <div class=\"col-md-6\"><h4>Mã nhân viên: ");
            EndContext();
            BeginContext(1079, 7, false);
#line 29 "E:\Repos\Assignment01\Assignment01\Views\Nhanvien\Xoa.cshtml"
                                           Write(nvct.Id);

#line default
#line hidden
            EndContext();
            BeginContext(1086, 62, true);
            WriteLiteral("</h4></div>\r\n        <div class=\"col-md-6\"><h4>Số điện thoại: ");
            EndContext();
            BeginContext(1149, 8, false);
#line 30 "E:\Repos\Assignment01\Assignment01\Views\Nhanvien\Xoa.cshtml"
                                            Write(nvct.Sdt);

#line default
#line hidden
            EndContext();
            BeginContext(1157, 59, true);
            WriteLiteral("</h4></div>\r\n        <div class=\"col-md-6\"><h4>Trạng thái: ");
            EndContext();
            BeginContext(1217, 14, false);
#line 31 "E:\Repos\Assignment01\Assignment01\Views\Nhanvien\Xoa.cshtml"
                                         Write(nvct.Trangthai);

#line default
#line hidden
            EndContext();
            BeginContext(1231, 158, true);
            WriteLiteral("</h4></div>\r\n\r\n    </div>\r\n    <div class=\"row\" style=\"margin-top: 40px;\">\r\n        <div class=\"col-md-6\"></div>\r\n        <div class=\"col-md-6\">\r\n            ");
            EndContext();
            BeginContext(1389, 274, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "944771adeff24d0f888a227529acfc5e", async() => {
                BeginContext(1441, 215, true);
                WriteLiteral("\r\n                <input type=\"hidden\" value=\"1\"/>\r\n                <button class=\"btn btn-danger\" type=\"submit\">Xóa</button>\r\n                <a class=\"btn btn-info\" href=\"/NhanVien/Danhsach/\">Hủy</a>\r\n            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1417, "/NhanVien/Xoa/", 1417, 14, true);
#line 37 "E:\Repos\Assignment01\Assignment01\Views\Nhanvien\Xoa.cshtml"
AddHtmlAttributeValue("", 1431, nvct.Id, 1431, 8, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1663, 36, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>");
            EndContext();
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