using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Shopping_List_API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_List_API.Services
{
    public class ShoppingService
    {
        private MLDevelopmentContext _db;

        public ShoppingService(MLDevelopmentContext db)
        {
            _db = db;
        }

        public List GetListByAccountId(int id)
        {
            //get all the items
            var list = _db.Lists.FirstOrDefault(l => l.Account.AccountId == id);
            list.ListItems = GetListItemsByListId(list.ListId);
            return list;
        }
        public ICollection<ListItem> GetListItemsByListId(int id)
        {
            return  _db.ListItems.Where(li => li.List.ListId == id).ToList();
        }
    }
}
