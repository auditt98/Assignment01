#pragma checksum "E:\Repos\Assignment01\Assignment01\Views\DanhMuc\PhongBan\Sua.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e3f2ba70c855d103c8e11782e84e37813f054bf4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_DanhMuc_PhongBan_Sua), @"mvc.1.0.view", @"/Views/DanhMuc/PhongBan/Sua.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/DanhMuc/PhongBan/Sua.cshtml", typeof(AspNetCore.Views_DanhMuc_PhongBan_Sua))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e3f2ba70c855d103c8e11782e84e37813f054bf4", @"/Views/DanhMuc/PhongBan/Sua.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7c54143f46862f8ba6a2b7cb07772efe59ecd11f", @"/Views/_ViewImports.cshtml")]
    public class Views_DanhMuc_PhongBan_Sua : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
#line 2 "E:\Repos\Assignment01\Assignment01\Views\DanhMuc\PhongBan\Sua.cshtml"
  
    var thongTinNhanVien = ViewData["thongTinNhanVien"] as NhanVien;
    var thongTinPhongBan = ViewData["thongTinPhongBan"] as PhongBan;
    ViewData["Title"] = "Sửa phòng ban";

#line default
#line hidden
            BeginContext(191, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 8 "E:\Repos\Assignment01\Assignment01\Views\DanhMuc\PhongBan\Sua.cshtml"
  
    Html.RenderPartial("Nav");

#line default
#line hidden
            BeginContext(232, 171, true);
            WriteLiteral("\r\n<div id=\"page-wrapper\">\r\n    <div class=\"row\">\r\n        <div class=\"col-lg-12\">\r\n            <h1 class=\"page-header\">Sửa phòng ban</h1>\r\n        </div>\r\n    </div>\r\n    ");
            EndContext();
            BeginContext(403, 1086, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9e83c4c258f5470693414cf991e270fd", async() => {
                BeginContext(503, 204, true);
                WriteLiteral("\r\n        <div class=\"form-group\">\r\n            <label for=\"inputName\" class=\"col-sm-2 control-label\">Mã phòng ban:</label>\r\n            <div class=\"col-sm-6\">\r\n                <input class=\"form-control\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 707, "\"", 750, 1);
#line 22 "E:\Repos\Assignment01\Assignment01\Views\DanhMuc\PhongBan\Sua.cshtml"
WriteAttributeValue("", 715, thongTinPhongBan.Idpban.ToString(), 715, 35, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(751, 333, true);
                WriteLiteral(@" disabled />
            </div>
        </div>
        <div class=""form-group"">
            <label for=""inputName"" class=""col-sm-2 control-label"">Tên phòng ban <span style=""color:red"">(*)</span>:</label>
            <div class=""col-sm-6"">
                <input type=""text"" class=""form-control"" name=""editPbName"" id=""inputName""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1084, "\"", 1117, 1);
#line 28 "E:\Repos\Assignment01\Assignment01\Views\DanhMuc\PhongBan\Sua.cshtml"
WriteAttributeValue("", 1092, thongTinPhongBan.Tenpban, 1092, 25, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1118, 364, true);
                WriteLiteral(@" placeholder=""Nhập tên phòng ban"" required>
            </div>
        </div>
        <div class=""row"">
            <div class=""col-sm-8"" style=""text-align: center;"">
                <button class=""btn btn-success"" type=""submit"">Lưu</button>
                <a class=""btn btn-danger"" href=""/DanhMuc/PhongBan"">Hủy</a>
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
            AddHtmlAttributeValue("", 455, "/DanhMuc/PhongBan/", 455, 18, true);
#line 18 "E:\Repos\Assignment01\Assignment01\Views\DanhMuc\PhongBan\Sua.cshtml"
AddHtmlAttributeValue("", 473, thongTinPhongBan.Idpban, 473, 24, false);

#line default
#line hidden
            AddHtmlAttributeValue("", 497, "/Sua", 497, 4, true);
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1489, 10, true);
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
