using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Client;
using SP = Microsoft.SharePoint.Client;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string userName = "Mitul@mitulpanchal.onmicrosoft.com";
            //Console.WriteLine("Enter your password.");
            SecureString password = GetPassword();
            // ClienContext - Get the context for the SharePoint Online Site  
            // SharePoint site URL - https://c986.sharepoint.com  

            using (var clientContext = new ClientContext("https://mitulpanchal.sharepoint.com/"))
            {
                // SharePoint Online Credentials  
                clientContext.Credentials = new SharePointOnlineCredentials(userName, password);
                Web oWebsite = clientContext.Web;
                ListCollection collList = oWebsite.Lists;

                clientContext.Load(collList);

                clientContext.ExecuteQuery();

                foreach (SP.List oList in collList)
                {
                    Console.WriteLine("Title: {0} Created: {1}", oList.Title, oList.Created.ToString());
                }

            }


        }

        private static SecureString GetPassword()
        {
            ConsoleKeyInfo info;
            //Get the user's password as a SecureString  
            SecureString securePassword = new SecureString();
            do
            {
                info = Console.ReadKey(true);
                if (info.Key != ConsoleKey.Enter)
                {
                    securePassword.AppendChar(info.KeyChar);
                }
            }
            while (info.Key != ConsoleKey.Enter);
            return securePassword;
        }
    }
}

