using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;


namespace LinqToXml.Samples.Sample02
{
    public class LinqQueryViewModel : CommonBase
    {
        #region GetAll Method
        public void GetAll()
        {
            StringBuilder sb = new StringBuilder(1024);
            XElement doc =
                  XElement.Load(AppSettings.Instance.CustomersFile);

            // Get All Customers
            //IEnumerable<XElement> orders =
            //        from order in doc.Elements("Customer")
            //        select order;
            IEnumerable<XElement> orders = doc.Elements("Customer");
            foreach (XElement order in orders)
            {
                sb.AppendLine(order.Element("CompanyName").Value);
            }

            ResultText = sb.ToString();
        }
        #endregion

        #region GetAllUsingXDocument Method
        public void GetAllUsingXDocument()
        {
            StringBuilder sb = new StringBuilder(1024);
            XDocument doc =
                  XDocument.Load(AppSettings.Instance.CustomersFile);

            // Get All Sales Order Headers

            IEnumerable<XElement> orders = doc.Descendants("Customer");


            foreach (XElement order in orders)
            {
                sb.AppendLine(order.Element("CompanyName").Value);
            }

            ResultText = sb.ToString();
        }
        #endregion

        #region SingleNode Method
        public void SingleNode()
        {
            XElement doc =
                  XElement.Load(AppSettings.Instance.CustomersFile);

            // Just use Elements() when using XElement class
            XElement customer = doc.Elements("Customer").FirstOrDefault();


            if (customer != null)
            {
                ResultText = customer.Element("CompanyName").Value;
            }
            else
            {
                ResultText = "Not Found";
            }
        }
        #endregion

        #region WhereClause Method
        public void WhereClause()
        {
            StringBuilder sb = new StringBuilder(1024);
            XElement doc =
                  XElement.Load(AppSettings.Instance.SalesOrderHeadersFile);

            // Get Sales Order Headers by CustomerID
            //IEnumerable<XElement> orders =
            //  from order in doc.Elements("SalesOrderHeader")
            //  where order.Element("CustomerID").Value == "187"
            //  select order;

            IEnumerable<XElement> orders = doc.Elements("SalesOrderHeader")
                .Where(x => x.Element("CustomerID").Value == "187");

            foreach (XElement order in orders)
            {
                sb.AppendLine(order.Element("SalesOrderNumber").Value);
            }

            ResultText = sb.ToString();
        }
        #endregion

        #region WhereClauseUsingAttribute Method
        public void WhereClauseUsingAttribute()
        {
            XElement doc =
                  XElement.Load(AppSettings.Instance.CustomersAttributesFile);

            //XElement customer = 
            //      (from cust in doc.Elements("Customer")
            //       where cust.Attribute("CustomerID").Value == "1"
            //       select cust).SingleOrDefault();
            XElement customer = doc.Elements("Customer")
                .Where(x => x.Attribute("CustomerID").Value == "1")
                .FirstOrDefault();
            if (customer != null)
            {
                ResultText = customer.Attribute("CompanyName").Value;
            }
            else
            {
                ResultText = "Not Found";
            }
        }
        #endregion

        #region OrderBy Method
        public void OrderBy()
        {
            StringBuilder sb = new StringBuilder(1024);
            XElement doc =
                  XElement.Load(AppSettings.Instance.CustomersFile);

            // Order By Company Name
            //IEnumerable<XElement> customers =
            //        from cust in doc.Elements("Customer")
            //        orderby cust.Element("CompanyName").Value
            //        select cust;

            IEnumerable<XElement> customers = doc.Elements("Customer")
                                              .OrderBy(x => x.Element("CompanyName").Value);



            foreach (var cust in customers)
            {
                sb.Append(cust.Element("CompanyName").Value);
                sb.Append(" - ");
                sb.Append(cust.Element("LastName").Value);
                sb.Append(",");
                sb.AppendLine(cust.Element("FirstName").Value);
            }

            ResultText = sb.ToString();
        }
        #endregion

        #region Join Method
        /// <summary>
        /// Join customers and orders, and create a new XML document with a different shape.
        /// </summary>
        public void Join()
        {

    //  <SalesOrderWithCustomerInfo >
    //       < Order >
            //       < CustomerID > 609 </ CustomerID >
            //       < CompanyName > Good Toys </ CompanyName >
            //       < FirstName > David </ FirstName >
            //       < LastName > Hodgson </ LastName 
            //       < OrderDate > 2004 - 06 - 01T00: 00:00 </ OrderDate >
            //       < SalesOrderNumber > SO71774 </ SalesOrderNumber >
    //       </Order >
    //  </ SalesOrderWithCustomerInfo >

                 XElement docCust;
            XElement docSales;

            // Load Customers XML File
            docCust = XElement.Load(AppSettings.Instance.CustomersFile);
            // Load Sales Header XML File
            docSales = XElement.Load(AppSettings.Instance.SalesOrderHeadersFile);



            var  newDoc = new XElement("SalesOrderWithCustomerInfo", docCust.Elements("Customer")
                  .Join(docSales.Elements("SalesOrderHeader"), c => c.Element("CustomerID").Value, o => o.Element("CustomerID").Value,
                  (c, o) => new XElement("Order",
                    new XElement("CustomerID", (string)c.Element("CustomerID")),
                    new XElement("CompanyName", (string)c.Element("CompanyName")),
                    new XElement("FirstName", (string)c.Element("FirstName")),
                    new XElement("LastName", (string)c.Element("LastName")),
                    new XElement("OrderDate", (DateTime)o.Element("OrderDate")),
                    new XElement("SalesOrderNumber", (string)o.Element("SalesOrderNumber"))
                  )).Where(x=>x.Element("CustomerID").Value=="609"));


            XElement funcMeth(XElement c, XElement o)
            {
                return new XElement("Order",
                    new XElement("CustomerID", (string)c.Element("CustomerID")),
                    new XElement("CompanyName", (string)c.Element("CompanyName")),
                    new XElement("FirstName", (string)c.Element("FirstName")),
                    new XElement("LastName", (string)c.Element("LastName")),
                    new XElement("OrderDate", (DateTime)o.Element("OrderDate")),
                    new XElement("SalesOrderNumber", (string)o.Element("SalesOrderNumber"))
                );
            }
            // Create new XElement object that has new shape
            //XElement newDoc =
            //  new XElement("SalesOrderWithCustomerInfo",
            //    from c in docCust.Elements("Customer")
            //    join o in docSales.Elements("SalesOrderHeader")
            //              on (string)c.Element("CustomerID") equals
            //                (string)o.Element("CustomerID")
            //    where c.Element("CustomerID").Value == "609"
            //    select new XElement("Order",
            //        new XElement("CustomerID", (string)c.Element("CustomerID")),
            //        new XElement("CompanyName", (string)c.Element("CompanyName")),
            //        new XElement("FirstName", (string)c.Element("FirstName")),
            //        new XElement("LastName", (string)c.Element("LastName")),
            //        new XElement("OrderDate", (DateTime)o.Element("OrderDate")),
            //        new XElement("SalesOrderNumber", (string)o.Element("SalesOrderNumber"))
            //    )
            //);

            ResultText = newDoc.ToString();
        }
        #endregion

        #region ReadConfig Method
        public void ReadConfig()
        {
            StringBuilder sb = new StringBuilder(1024);
            XElement doc =
                  XElement.Load(
                     AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            // Find <appSettings> element and get all <add> elements
            //IEnumerable<XElement> settings =
            //  (from setting in doc.Elements("appSettings").Elements("add")
            //   select setting);

         IEnumerable<XElement> settings=   doc.Elements("appSettings").Elements("add");

            if (settings != null)
            {
                foreach (var setting in settings)
                {
                    sb.Append("key: '");
                    sb.Append(setting.Attribute("key").Value);
                    sb.Append("' - value: '");
                    sb.AppendLine(setting.Attribute("value").Value + "'");
                }

                ResultText = sb.ToString();
            }
            else
            {
                ResultText = "Not Found";
            }
        }
        #endregion

        #region LoadClasses Method
        public void LoadClasses()
        {
            StringBuilder sb = new StringBuilder(1024);
            XElement doc =
                  XElement.Load(AppSettings.Instance.CustomersFile);


            IEnumerable<Customer> customers = doc.Elements("Customer")
                                                  .OrderBy(x => x.Element("CompanyName").Value)
                                                  .Select(cust => new Customer
                                                  {
                                                      CustomerID = cust.Element("CustomerID").GetAs<int>(),
                                                      Title = cust.Element("Title").GetAs<string>(),
                                                      FirstName = cust.Element("FirstName").GetAs<string>(),
                                                      MiddleName = cust.Element("MiddleName").GetAs<string>(),
                                                      LastName = cust.Element("LastName").GetAs<string>(),
                                                      CompanyName = cust.Element("CompanyName").GetAs<string>(),
                                                      SalesPerson = cust.Element("SalesPerson").GetAs<string>(),
                                                      EmailAddress = cust.Element("EmailAddress").GetAs<string>(),
                                                      Phone = cust.Element("Phone").GetAs<string>()
                                                  }
                                                  );

            // Order By Display Order
            //List<Customer> customers =
            //  (from cust in doc.Elements("Customer")
            //   orderby cust.Element("CompanyName").Value
            //   select new Customer
            //   {
            //       CustomerID = cust.Element("CustomerID").GetAs<int>(),
            //       Title = cust.Element("Title").GetAs<string>(),
            //       FirstName = cust.Element("FirstName").GetAs<string>(),
            //       MiddleName = cust.Element("MiddleName").GetAs<string>(),
            //       LastName = cust.Element("LastName").GetAs<string>(),
            //       CompanyName = cust.Element("CompanyName").GetAs<string>(),
            //       SalesPerson = cust.Element("SalesPerson").GetAs<string>(),
            //       EmailAddress = cust.Element("EmailAddress").GetAs<string>(),
            //       Phone = cust.Element("Phone").GetAs<string>()
            //   }).ToList();

            foreach (Customer cust in customers)
            {
                sb.AppendLine("Company Name: " + cust.CompanyName);
                sb.AppendLine("   Name: " + cust.LastName + ", " + cust.FirstName);
                sb.AppendLine("   SalesPerson: " + cust.SalesPerson);
                sb.AppendLine("   EmailAddres: " + cust.EmailAddress);
                sb.AppendLine("   Phone: " + cust.Phone);
            }

            ResultText = sb.ToString();
        }
        #endregion
    }
}
