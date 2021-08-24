using HicadStockSystem.Core.IRespository;
using HicadStockSystem.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.Utilities.PdfConverter
{
    public class TemplateGenerator
    {
        private readonly ISt_StkSystem _system;
        private readonly ISt_Requisition _requisition;

        public TemplateGenerator(ISt_StkSystem system, ISt_Requisition requisition)
        {
            _system = system;
            _requisition = requisition;
        }
        
        public string GetHTMLString(string reqno)
        {
            var requisition = _requisition.RequesitionsVM(reqno);
            var system = _system.GetSingle();

            var sb = new StringBuilder();

            sb.Append(@"
                <html>
                    <head></head>
                    <body>
                       <div class='header'>
                         <h1></h1>
                         <h2></h2>
                       </div>
                       <div>
                        <h3>Requisition No.</h3>
                        <h3>Requisition Date</h3>
                        <h3>Requistioned by</h3>
                        <h3>Department</h3>
                       </div>
                        <table align='center'>
                            <tr>
                                <th>Item Code</th>
                                <th>Description</th>
                                <th>unit</th>
                                <th>Quantity</th>
                ");
            sb.AppendFormat(@"<div class='header'>
                                <h1>{0}</h1>
                                <h2>{1}</h2>
                              </div>",
                              system.CompanyName, system.CompanyAddress);
            sb.AppendFormat(@"
                           <div>
                            <h3>{0}</h3>
                            <h3>{1}</h3>
                            <h3>{2}</h3>
                            <h3>{3}</h3>
                           </div>", reqno, requisition.DateAndTime, requisition.RequisitionBy, requisition.Department);
            foreach (var item in requisition.ItemLists)
            {
                sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                                  </tr>", item.ItemCode, item.ItemDescription, item.Unit, item.Quantity);
            }
            sb.Append(@"
                        </table>
                       </body>
                    </html>");
            return sb.ToString();
        }
    }
}
