/***
This File is part of FluentCamlGen

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
***/

using System;

namespace FluentCamlGen.CamlGen
{
    /// <summary>
    /// Create &lt;Join Type="INNER" ListAlias="...">
    /// <seealso cref="http://msdn.microsoft.com/en-us/library/ee535061(v=office.15).aspx"/>
    /// </summary>
    public class CamlJoin : BaseCamlTag
    {
        public class JoinType
        {
            private readonly string _type;

            private JoinType(string type)
            {
                _type = type;
            }

            public static readonly JoinType Inner = new JoinType("INNER");
            public static readonly JoinType Left = new JoinType("LEFT");

            public override string ToString()
            {
                return _type;
            }
        }

        private readonly CamlEq _innerEq;

        internal CamlJoin(string listName, JoinType type, string joinField)
            : this(listName, type)
        {
            _innerEq.Childs.Add(new CamlFieldRef(joinField).AddAttribute("RefType", "Id"));
            _innerEq.Childs.Add(new CamlFieldRef("ID").AddAttribute("List", listName));
        }

        internal CamlJoin(string listName, JoinType type, ITag lhs, ITag rhs)
            : this(listName, type)
        {
            _innerEq.Childs.Add(lhs);
            _innerEq.Childs.Add(rhs);
        }

        internal CamlJoin(string listName, JoinType type)
            : base("Join", new[]
                {
                    new Tuple<string, string>("Type", type.ToString()),
                    new Tuple<string, string>("ListAlias", listName)
                }, null)
        {
            _innerEq = new CamlEq();
            Childs.Add(_innerEq);
        }

        public CamlJoin AddFieldRef(string name, Action<CamlFieldRef> action)
        {
            _innerEq.AddFieldRef(name, action);
            return this;
        }

        //TODO: AddValue fehlt
    }
}