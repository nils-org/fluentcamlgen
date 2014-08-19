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

namespace FluentCamlGen.CamlGen.Elements.Core
{
    /// <summary>
    /// Create &lt;Join Type="INNER" ListAlias="...">
    /// <seealso cref="http://msdn.microsoft.com/en-us/library/ee535061(v=office.15).aspx"/>
    /// </summary>
    public class Join : BaseCoreElement
    {
        /// <summary>
        /// possible JoinTypes to add on a Join 
        /// </summary>
        public class JoinType
        {
            private readonly string _type;

            private JoinType(string type)
            {
                _type = type;
            }

            /// <summary>
            /// LEFT
            /// </summary>
            public static readonly JoinType Inner = new JoinType("INNER");

            /// <summary>
            /// INNER
            /// </summary>
            public static readonly JoinType Left = new JoinType("LEFT");

            public override string ToString()
            {
                return _type;
            }
        }

        private readonly Eq _innerEq;

        internal Join(string listName, JoinType type, string joinField)
            : this(listName, type)
        {
            _innerEq.Childs.Add(new FieldRef(joinField).AddAttribute("RefType", "Id"));
            _innerEq.Childs.Add(new FieldRef("ID").AddAttribute("List", listName));
        }

        internal Join(string listName, JoinType type, BaseElement lhs, BaseElement rhs)
            : this(listName, type)
        {
            _innerEq.Childs.Add(lhs);
            _innerEq.Childs.Add(rhs);
        }

        internal Join(string listName, JoinType type)
            : base("Join", new[]
                {
                    new Tuple<string, string>("Type", type.ToString()),
                    new Tuple<string, string>("ListAlias", listName)
                }, null)
        {
            _innerEq = new Eq();
            Childs.Add(_innerEq);
        }

        public Join AddFieldRef(string name, Action<FieldRef> action)
        {
            _innerEq.AddFieldRef(name, action);
            return this;
        }

        //TODO: AddValue fehlt
    }
}