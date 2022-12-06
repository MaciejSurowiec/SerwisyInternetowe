#pragma checksum "C:\Users\suruw\source\repos\SerwisyInternetowe\SerwisyInternetowe\SerwisyInternetowe\Pages\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "19b61a276a460e9467066b85dd617c5bfbedfd32"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(SerwisyInternetowe.Pages.Pages_Index), @"mvc.1.0.razor-page", @"/Pages/Index.cshtml")]
namespace SerwisyInternetowe.Pages
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
#line 1 "C:\Users\suruw\source\repos\SerwisyInternetowe\SerwisyInternetowe\SerwisyInternetowe\Pages\_ViewImports.cshtml"
using SerwisyInternetowe;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"19b61a276a460e9467066b85dd617c5bfbedfd32", @"/Pages/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"04407123a01d8a37a576656973732c52aff1a900", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\suruw\source\repos\SerwisyInternetowe\SerwisyInternetowe\SerwisyInternetowe\Pages\Index.cshtml"
  
    ViewData["Title"] = "Home page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""text-center"">
    <table>
        <tr>
            <td>
                <p>temperatura</p>
            </td>
            <td>
                <p>cisnienie</p>
            </td>
            <td>
                <p>czas</p>
            </td>
            <td>
                <p>guid</p>
            </td>
        </tr>
");
#nullable restore
#line 23 "C:\Users\suruw\source\repos\SerwisyInternetowe\SerwisyInternetowe\SerwisyInternetowe\Pages\Index.cshtml"
         foreach (var item in Model.tempArray)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr class=\"item\">\r\n                <td class=\"Temp\">\r\n                    ");
#nullable restore
#line 27 "C:\Users\suruw\source\repos\SerwisyInternetowe\SerwisyInternetowe\SerwisyInternetowe\Pages\Index.cshtml"
               Write(item.Temp);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td class=\"cisnienie\">\r\n                    ");
#nullable restore
#line 30 "C:\Users\suruw\source\repos\SerwisyInternetowe\SerwisyInternetowe\SerwisyInternetowe\Pages\Index.cshtml"
               Write(item.cisnienie);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td class=\"timestamp\">\r\n                    ");
#nullable restore
#line 33 "C:\Users\suruw\source\repos\SerwisyInternetowe\SerwisyInternetowe\SerwisyInternetowe\Pages\Index.cshtml"
               Write(item.timestamp);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td class=\"guid\">\r\n                    ");
#nullable restore
#line 36 "C:\Users\suruw\source\repos\SerwisyInternetowe\SerwisyInternetowe\SerwisyInternetowe\Pages\Index.cshtml"
               Write(item.guid);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 39 "C:\Users\suruw\source\repos\SerwisyInternetowe\SerwisyInternetowe\SerwisyInternetowe\Pages\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </table>
    <div style=""width:75%;"">
        <canvas id=""canvas""></canvas>
    </div>
    <br>
    <br>
    <script>

        let myArray = document.getElementsByClassName(""guid"");
        var otherArray = [];

        for (var index = 0; index < myArray.length; ++index) {
            otherArray.push(myArray[index].textContent.trim())
        }


        let guids = [...new Set(otherArray)];
        var datasets = [];
        var colorNames = Object.keys(window.chartColors);
        let items = document.getElementsByClassName(""item"");
        for (var index = 0; index < guids.length; ++index) {
            var colorName = colorNames[(index+1) % colorNames.length];
            var newColor = window.chartColors[colorName];
            var newDataset = {
                label: guids[index],
                backgroundColor: newColor,
                borderColor: newColor,
                data: [],
                fill: false
            };

            for (var i = 0; i < items");
            WriteLiteral(@".length; i++) {
                if (items[i].getElementsByClassName(""guid"")[0].textContent.trim() == guids[index]) {
                    newDataset.data.push(Number(items[i].getElementsByClassName(""Temp"")[0].textContent.trim()));
                }
            }
            datasets.push(newDataset);
        }

        console.log(datasets);

        var config = {
            type: 'line',
            data: { datasets },
            options: {
                responsive: true,
                title: {
                    display: true,
                    text: 'Chart.js Line Chart'
                },
                tooltips: {
                    mode: 'index',
                    intersect: false,
                },
                hover: {
                    mode: 'nearest',
                    intersect: true
                },
                scales: {
                    xAxes: [{
                        display: true,
                        scaleLabel: {
              ");
            WriteLiteral(@"              display: true,
                            labelString: 'Guid'
                        }
                    }],
                    yAxes: [{
                        display: true,
                        scaleLabel: {
                            display: true,
                            labelString: 'temperature'
                        }
                    }]
                }
            }
        };
        console.log(config.data);
        window.onload = function () {
            var ctx = document.getElementById(""canvas"").getContext(""2d"");
            window.myLine = new Chart(ctx, config);
        };
       
    </script>

    <p>Learn about <a href=""https://docs.microsoft.com/aspnet/core"">building Web apps with ASP.NET Core</a>.</p>
</div>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel>)PageContext?.ViewData;
        public IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
