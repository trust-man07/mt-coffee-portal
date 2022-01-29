
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Collections.Generic;
using System.Web;
using System.Security.Claims;

namespace MtCoffee.Web
{
    public static class Permissions
    {
        public const System.String CanWatchOtherPeoplePlayVideoGames = "entertainment.videogames.view";
        public const System.String CanViewProducts = "products.view";

        private static readonly Dictionary<string, string> ValuesMap = new Dictionary<string, string>()
        {
            { "CanWatchOtherPeoplePlayVideoGames", "entertainment.videogames.view" },
            { "CanViewProducts", "products.view" },
        };


        //Role -> permissions[]
        public static readonly Dictionary<string, HashSet<string>> RolePermissions = new Dictionary<string, HashSet<string>>()
        {
            { "Guest", new HashSet<string>(){ "products.view" }},
            { "Customer", new HashSet<string>(){ "products.view" }},
            { "Employee", new HashSet<string>(){ "products.view" }},
            { "Manager", new HashSet<string>(){ "products.view" }},
            { "Admin", new HashSet<string>(){ "entertainment.videogames.view","products.view" }},
        };

        public static List<string> Values { get => ValuesMap.Values.ToList(); }
        public static List<string> Keys { get => ValuesMap.Keys.ToList(); }
        
        // CanDoThing => thing.can.do
        public static List<KeyValuePair<string,string>> ToList()
        {
            return ValuesMap.ToList();
        }

        /// <summary>
        /// Lists all roles that have the given fully qualified permission node.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static List<string> GetRolesThatHavePermission(string node)
        {
            List<string> items = new List<string>();

            foreach(var grp in Permissions.RolePermissions.Keys)
            {
                if (Permissions.HasPermissionByRole(grp, node))
                {
                    items.Add(grp);
                }
            }

            return items;
        }


        ///<summary>
        /// This method checks to see if any of the roles in the rolecsv (list of roles, separated by commas)
        /// have the requested permission node. Returns true if any of them do. The full qualified permission
        /// node needs to come from the pre-defined constant values.
        ///</summary>
        public static bool HasPermissionByRole(string roleCsv, string fullyQualifiedPermissionNode)
        {
			if (string.IsNullOrWhiteSpace(roleCsv)) return false;
            string[] roles = roleCsv.Split(',').Select(x => x.Trim()).ToArray();

            foreach(string role in roles)
            {
                if (RolePermissions.ContainsKey(role))
                {
                    var perms = RolePermissions[role];
                    if (perms != null && perms.Contains(fullyQualifiedPermissionNode))
                    {
                        return true;
                    }
                }
            }

            return false;
        }


        public static void AddPermission(string role, string node)
        {
            if (!RolePermissions.ContainsKey(role)) RolePermissions[role] = new HashSet<string>();
            var nodes = GetFullyQualifiedPermissionNodes(node);

            foreach(string fq in nodes)
            {
                RolePermissions[role].Add(fq);
            }
        }

        public static void AddPermissions(string role, HashSet<string> nodes)
        {
            if (!RolePermissions.ContainsKey(role)) 
            {
                RolePermissions[role] = new HashSet<string>();
            }

            foreach(string s in nodes)
            {
                var fqNodes = GetFullyQualifiedPermissionNodes(s);
                foreach(string fq in fqNodes)
                {
                    RolePermissions[role].Add(fq);
                }
            }
        }
    
        private static HashSet<string> GetFullyQualifiedPermissionNodes(string nodeWithPossibleWildCard)
        {
            HashSet<string> nodes = new HashSet<string>();
            if (ValuesMap.Values.Contains(nodeWithPossibleWildCard))
            {
                nodes.Add(nodeWithPossibleWildCard);
            }
            else
            {
                // must be either not found, or a wildcard. Wildcard if ending in *
                if (nodeWithPossibleWildCard.EndsWith("*"))
                {
                    if (nodeWithPossibleWildCard == "*")
                    {
                        foreach(string fq in ValuesMap.Values)
                        {
                            nodes.Add(fq);
                        }
                    }
                    else if (nodeWithPossibleWildCard.EndsWith(".*"))
                    {
                        string needle = nodeWithPossibleWildCard.Substring(0, nodeWithPossibleWildCard.Length - 2);
                        foreach (string fq in ValuesMap.Values.Where(x => x.StartsWith(needle)))
                        {
                            nodes.Add(fq);
                        }
                    }
                }
            }

            return nodes;
        }
        

  
    }

    public class PermissionSet
    {
        public bool CanWatchOtherPeoplePlayVideoGames => this.PermissionsGranted["CanWatchOtherPeoplePlayVideoGames"];
        public bool CanViewProducts => this.PermissionsGranted["CanViewProducts"];

        private Dictionary<string, bool> PermissionsGranted { get; }
        public string[] Roles { get; }
        public bool IsAuthenticated { get; set; } = false;

        public PermissionSet(string roleCsv)
        {
            // CanDo => can.do
            this.Roles = roleCsv?.Split(",") ?? new string[0];
            this.PermissionsGranted = new Dictionary<string, bool>();
            Permissions.ToList().ForEach(kvp => this.PermissionsGranted[kvp.Key] = Permissions.HasPermissionByRole(roleCsv, kvp.Value));
        }
    }

}
    
        namespace Microsoft.AspNetCore.Authorization {
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
        public class HasPermissionAttribute : Attribute, Mvc.Filters.IAuthorizationFilter
        {
            public string[] Nodes { get; set; }
            public HasPermissionAttribute(params string[] PermissionNodes)
            {
                this.Nodes = PermissionNodes;
            }

            public void OnAuthorization(Mvc.Filters.AuthorizationFilterContext context)
            {
                var roleCsv = context.HttpContext.User?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value ?? "";

                foreach (string fqNode in this.Nodes)
                {
                    if (MtCoffee.Web.Permissions.HasPermissionByRole(fqNode, roleCsv))
                    {
                        return; // Good to go. You have permission.
                    }
                }
            
                var result = new MtCoffee.Web.Models.JsonPayload<object>();
                if (Nodes.Length == 1)
                {
                    result.Errors.Add(string.Format("You do not have permission to perform the current operation. You lack the '{0}' permission node. If you feel this is in error, please contact an administrator.", Nodes[0]));
                }
                else
                {
                    result.Errors.Add(string.Format("You do not have permission to perform the current operation. You must have at least one of the following permissions: [{0}]", string.Join(",", Nodes)));
                }

                context.Result = result.ToJsonResult(401);
            }
        }
    }
    
