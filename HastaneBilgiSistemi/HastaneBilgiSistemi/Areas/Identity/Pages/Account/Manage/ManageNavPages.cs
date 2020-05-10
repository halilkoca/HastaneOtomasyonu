using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HastaneBilgiSistemi.Areas.Identity.Pages.Account.Manage
{
    public static class ManageNavPages
    {
        public static string Index => "Index";
        public static string Email => "Email";
        public static string Reservation => "Reservation";
        public static string History => "History";
        public static string ChangePassword => "ChangePassword";
        public static string ExternalLogins => "ExternalLogins";
        public static string PersonalData => "PersonalData";
        public static string TwoFactorAuthentication => "TwoFactorAuthentication";

        
        public static string IndexNavClass(ViewContext viewContext) => PageNavClass(viewContext, Index);
        public static string ReservationNavClass(ViewContext viewContext) => PageNavClass(viewContext, Reservation);
        public static string HistoryNavClass(ViewContext viewContext) => PageNavClass(viewContext, History);
        public static string EmailNavClass(ViewContext viewContext) => PageNavClass(viewContext, Email);
        public static string ChangePasswordNavClass(ViewContext viewContext) => PageNavClass(viewContext, ChangePassword);
        public static string ExternalLoginsNavClass(ViewContext viewContext) => PageNavClass(viewContext, ExternalLogins);
        public static string PersonalDataNavClass(ViewContext viewContext) => PageNavClass(viewContext, PersonalData);
        public static string TwoFactorAuthenticationNavClass(ViewContext viewContext) => PageNavClass(viewContext, TwoFactorAuthentication);
        
        
        private static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string
                ?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }
    }
}
