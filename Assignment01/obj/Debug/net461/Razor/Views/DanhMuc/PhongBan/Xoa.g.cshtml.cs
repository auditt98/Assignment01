#pragma checksum "E:\Repos\Assignment01\Assignment01\Views\DanhMuc\PhongBan\Xoa.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c7ffef83f6da15718eef150b7869406792648812"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_DanhMuc_PhongBan_Xoa), @"mvc.1.0.view", @"/Views/DanhMuc/PhongBan/Xoa.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/DanhMuc/PhongBan/Xoa.cshtml", typeof(AspNetCore.Views_DanhMuc_PhongBan_Xoa))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c7ffef83f6da15718eef150b7869406792648812", @"/Views/DanhMuc/PhongBan/Xoa.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7c54143f46862f8ba6a2b7cb07772efe59ecd11f", @"/Views/_ViewImports.cshtml")]
    public class Views_DanhMuc_PhongBan_Xoa : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-horizontal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "E:\Repos\Assignment01\Assignment01\Views\DanhMuc\PhongBan\Xoa.cshtml"
  
    var thongTinNhanVien = ViewData["thongTinNhanVien"] as NhanVien;
    var thongTinPhongBan = ViewData["thongTinPhongBan"] as PhongBan;
    ViewData["Title"] = "Xóa phòng ban";

#line default
#line hidden
            BeginContext(191, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 8 "E:\Repos\Assignment01\Assignment01\Views\DanhMuc\PhongBan\Xoa.cshtml"
  
    Html.RenderPartial("Nav");

#line default
#line hidden
            BeginContext(232, 184, true);
            WriteLiteral("\r\n<div id=\"page-wrapper\">\r\n    <div class=\"row\">\r\n        <div class=\"col-lg-12\">\r\n            <h1 class=\"page-header\">Bạn muốn xóa phòng ban này</h1>\r\n        </div>\r\n    </div>\r\n    ");
            EndContext();
            BeginContext(416, 1239, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "39c3d99250994e2484035a75114a82f8", async() => {
                BeginContext(516, 215, true);
                WriteLiteral("\r\n        <div class=\"form-group\">\r\n            <label for=\"inputId\" class=\"col-sm-2 control-label\">Mã phòng ban:</label>\r\n            <div class=\"col-sm-6\">\r\n                <input class=\"form-control\" id=\"inputId\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 731, "\"", 774, 1);
#line 22 "E:\Repos\Assignment01\Assignment01\Views\DanhMuc\PhongBan\Xoa.cshtml"
WriteAttributeValue("", 739, thongTinPhongBan.Idpban.ToString(), 739, 35, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(775, 68, true);
                WriteLiteral(" disabled />\r\n                <input type=\"hidden\" name=\"deletePbId\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 843, "\"", 886, 1);
#line 23 "E:\Repos\Assignment01\Assignment01\Views\DanhMuc\PhongBan\Xoa.cshtml"
WriteAttributeValue("", 851, thongTinPhongBan.Idpban.ToString(), 851, 35, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(887, 306, true);
                WriteLiteral(@" />
            </div>
        </div>
        <div class=""form-group"">
            <label for=""inputName"" class=""col-sm-2 control-label"">Tên phòng ban <span style=""color:red"">(*)</span>:</label>
            <div class=""col-sm-6"">
                <input type=""text"" class=""form-control"" id=""inputName""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1193, "\"", 1226, 1);
#line 29 "E:\Repos\Assignment01\Assignment01\Views\DanhMuc\PhongBan\Xoa.cshtml"
WriteAttributeValue("", 1201, thongTinPhongBan.Tenpban, 1201, 25, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1227, 68, true);
                WriteLiteral(" disabled>\r\n                <input type=\"hidden\" name=\"deletePbName\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1295, "\"", 1328, 1);
#line 30 "E:\Repos\Assignment01\Assignment01\Views\DanhMuc\PhongBan\Xoa.cshtml"
WriteAttributeValue("", 1303, thongTinPhongBan.Tenpban, 1303, 25, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1329, 319, true);
                WriteLiteral(@">
            </div>
        </div>
        <div class=""row"">
            <div class=""col-sm-8"" style=""text-align: center;"">
                <button class=""btn btn-danger"" type=""submit"">Xóa</button>
                <a class=""btn btn-info"" href=""/DanhMuc/PhongBan"">Hủy</a>
            </div>
        </div>
    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 3, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 468, "/DanhMuc/PhongBan/", 468, 18, true);
#line 18 "E:\Repos\Assignment01\Assignment01\Views\DanhMuc\PhongBan\Xoa.cshtml"
AddHtmlAttributeValue("", 486, thongTinPhongBan.Idpban, 486, 24, false);

#line default
#line hidden
            AddHtmlAttributeValue("", 510, "/Xoa", 510, 4, true);
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1655, 10, true);
            WriteLiteral("\r\n\r\n</div>");
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
