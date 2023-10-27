/*
This File is part of FluentCamlGen

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
*/

using System;
using FluentCamlGen.CamlGen.Elements.Core;

namespace FluentCamlGen.CamlGen
{
    /// <summary>
    /// Nice Extensions to work on ComparingGroup-Elements.
    /// </summary>
    public static class BaseCoreComparingGroupElementExtensions
    {
        /// <summary>
        /// Add an &lt;Eq>-Tag.
        /// </summary>
        /// <param name="parent">The extended <see cref="BaseCoreComparingGroupElement"/>.</param>
        /// <typeparam name="T">The concrete type that is extended.</typeparam>
        /// <returns><see cref="BaseCoreComparingGroupElement{T}"/>.</returns>
        public static T Eq<T>(this T parent)
            where T : BaseCoreComparingGroupElement<T>
        {
            return Eq(parent, x => { });
        }

        /// <summary>
        /// Add an &lt;Eq>-Tag.
        /// </summary>
        /// <param name="parent">The extended <see cref="BaseCoreComparingGroupElement"/>.</param>
        /// <param name="action">Fluent configuration of the <see cref="Eq"/>.</param>
        /// <typeparam name="T">The concrete type that is extended.</typeparam>
        /// <returns><see cref="BaseCoreComparingGroupElement{T}"/>.</returns>
        public static T Eq<T>(this T parent, Action<Eq> action)
            where T : BaseCoreComparingGroupElement<T>
        {
            var eq = new Eq();
            action(eq);
            parent.Childs.Add(eq);
            return parent;
        }

        /// <summary>
        /// Add a &lt;Neq>-Tag.
        /// </summary>
        /// <param name="parent">The extended <see cref="BaseCoreComparingGroupElement"/>.</param>
        /// <typeparam name="T">The concrete type that is extended.</typeparam>
        /// <returns><see cref="BaseCoreComparingGroupElement{T}"/>.</returns>
        public static T Neq<T>(this T parent)
            where T : BaseCoreComparingGroupElement<T>
        {
            return Neq(parent, x => { });
        }

        /// <summary>
        /// Add a &lt;Neq>-Tag.
        /// </summary>
        /// <param name="parent">The extended <see cref="BaseCoreComparingGroupElement"/>.</param>
        /// <param name="action">Fluent configuration of the <see cref="Neq"/>.</param>
        /// <typeparam name="T">The concrete type that is extended.</typeparam>
        /// <returns><see cref="BaseCoreComparingGroupElement{T}"/>.</returns>
        public static T Neq<T>(this T parent, Action<Neq> action)
            where T : BaseCoreComparingGroupElement<T>
        {
            var neq = new Neq();
            action(neq);
            parent.Childs.Add(neq);
            return parent;
        }

        /// <summary>
        /// Add a &lt;Gt>-Tag.
        /// </summary>
        /// <param name="parent">The extended <see cref="BaseCoreComparingGroupElement"/>.</param>
        /// <typeparam name="T">The concrete type that is extended.</typeparam>
        /// <returns><see cref="BaseCoreComparingGroupElement{T}"/>.</returns>
        public static T Gt<T>(this T parent)
            where T : BaseCoreComparingGroupElement<T>
        {
            return Gt(parent, x => { });
        }

        /// <summary>
        /// Add a &lt;Gt>-Tag.
        /// </summary>
        /// <param name="parent">The extended <see cref="BaseCoreComparingGroupElement"/>.</param>
        /// <param name="action">Fluent configuration of the <see cref="Gt"/>.</param>
        /// <typeparam name="T">The concrete type that is extended.</typeparam>
        /// <returns><see cref="BaseCoreComparingGroupElement{T}"/>.</returns>
        public static T Gt<T>(this T parent, Action<Gt> action)
            where T : BaseCoreComparingGroupElement<T>
        {
            var gt = new Gt();
            action(gt);
            parent.Childs.Add(gt);
            return parent;
        }

        /// <summary>
        /// Add a &lt;Geq>-Tag.
        /// </summary>
        /// <param name="parent">The extended <see cref="BaseCoreComparingGroupElement"/>.</param>
        /// <typeparam name="T">The concrete type that is extended.</typeparam>
        /// <returns><see cref="BaseCoreComparingGroupElement{T}"/>.</returns>
        public static T Geq<T>(this T parent)
            where T : BaseCoreComparingGroupElement<T>
        {
            return Geq(parent, x => { });
        }

        /// <summary>
        /// Add a &lt;Geq>-Tag.
        /// </summary>
        /// <param name="parent">The extended <see cref="BaseCoreComparingGroupElement"/>.</param>
        /// <param name="action">Fluent configuration of the <see cref="Geq"/>.</param>
        /// <typeparam name="T">The concrete type that is extended.</typeparam>
        /// <returns><see cref="BaseCoreComparingGroupElement{T}"/>.</returns>
        public static T Geq<T>(this T parent, Action<Geq> action)
            where T : BaseCoreComparingGroupElement<T>
        {
            var geq = new Geq();
            action(geq);
            parent.Childs.Add(geq);
            return parent;
        }

        /// <summary>
        /// Add a &lt;Lt>-Tag.
        /// </summary>
        /// <param name="parent">The extended <see cref="BaseCoreComparingGroupElement"/>.</param>
        /// <typeparam name="T">The concrete type that is extended.</typeparam>
        /// <returns><see cref="BaseCoreComparingGroupElement{T}"/>.</returns>
        public static T Lt<T>(this T parent)
            where T : BaseCoreComparingGroupElement<T>
        {
            return Lt(parent, x => { });
        }

        /// <summary>
        /// Add a &lt;Lt>-Tag.
        /// </summary>
        /// <param name="parent">The extended <see cref="BaseCoreComparingGroupElement"/>.</param>
        /// <param name="action">Fluent configuration of the <see cref="Lt"/>.</param>
        /// <typeparam name="T">The concrete type that is extended.</typeparam>
        /// <returns><see cref="BaseCoreComparingGroupElement{T}"/>.</returns>
        public static T Lt<T>(this T parent, Action<Lt> action)
            where T : BaseCoreComparingGroupElement<T>
        {
            var lt = new Lt();
            action(lt);
            parent.Childs.Add(lt);
            return parent;
        }

        /// <summary>
        /// Add a &lt;Leq>-Tag.
        /// </summary>
        /// <param name="parent">The extended <see cref="BaseCoreComparingGroupElement"/>.</param>
        /// <typeparam name="T">The concrete type that is extended.</typeparam>
        /// <returns><see cref="BaseCoreComparingGroupElement{T}"/>.</returns>
        public static T Leq<T>(this T parent)
            where T : BaseCoreComparingGroupElement<T>
        {
            return Leq(parent, x => { });
        }

        /// <summary>
        /// Add a &lt;Leq>-Tag.
        /// </summary>
        /// <param name="parent">The extended <see cref="BaseCoreComparingGroupElement"/>.</param>
        /// <param name="action">Fluent configuration of the <see cref="Leq"/>.</param>
        /// <typeparam name="T">The concrete type that is extended.</typeparam>
        /// <returns><see cref="BaseCoreComparingGroupElement{T}"/>.</returns>
        public static T Leq<T>(this T parent, Action<Leq> action)
            where T : BaseCoreComparingGroupElement<T>
        {
            var leq = new Leq();
            action(leq);
            parent.Childs.Add(leq);
            return parent;
        }

        /// <summary>
        /// Add an &lt;And>-Tag.
        /// </summary>
        /// <param name="parent">The extended <see cref="BaseCoreComparingGroupElement"/>.</param>
        /// <typeparam name="T">The concrete type that is extended.</typeparam>
        /// <returns><see cref="BaseCoreComparingGroupElement{T}"/>.</returns>
        public static T And<T>(this T parent)
            where T : BaseCoreComparingGroupElement<T>
        {
            return And(parent, x => { });
        }

        /// <summary>
        /// Add an &lt;And>-Tag.
        /// </summary>
        /// <param name="parent">The extended <see cref="BaseCoreComparingGroupElement"/>.</param>
        /// <param name="action">Fluent configuration of the <see cref="And"/>.</param>
        /// <typeparam name="T">The concrete type that is extended.</typeparam>
        /// <returns><see cref="BaseCoreComparingGroupElement{T}"/>.</returns>
        public static T And<T>(this T parent, Action<And> action)
            where T : BaseCoreComparingGroupElement<T>
        {
            var and = new And();
            action(and);
            parent.Childs.Add(and);
            return parent;
        }

        /// <summary>
        /// Add a nested &lt;Or>-Tag.
        /// </summary>
        /// <param name="parent">The extended <see cref="BaseCoreComparingGroupElement"/>.</param>
        /// <typeparam name="T">The concrete type that is extended.</typeparam>
        /// <returns><see cref="BaseCoreComparingGroupElement{T}"/>.</returns>
        public static T Or<T>(this T parent)
            where T : BaseCoreComparingGroupElement<T>
        {
            return Or(parent, x => { });
        }

        /// <summary>
        /// Add a nested &lt;Or>-Tag.
        /// </summary>
        /// <param name="parent">The extended <see cref="BaseCoreComparingGroupElement"/>.</param>
        /// <param name="action">Fluent configuration of the <see cref="Or"/>.</param>
        /// <typeparam name="T">The concrete type that is extended.</typeparam>
        /// <returns><see cref="BaseCoreComparingGroupElement{T}"/>.</returns>
        public static T Or<T>(this T parent, Action<Or> action)
            where T : BaseCoreComparingGroupElement<T>
        {
            var or = new Or();
            action(or);
            parent.Childs.Add(or);
            return parent;
        }

        /// <summary>
        /// Add an &lt;Contains>-Tag.
        /// </summary>
        /// <param name="parent">The extended <see cref="BaseCoreComparingGroupElement"/>.</param>
        /// <typeparam name="T">The concrete type that is extended.</typeparam>
        /// <returns><see cref="BaseCoreComparingGroupElement{T}"/>.</returns>
        public static T Contains<T>(this T parent)
            where T : BaseCoreComparingGroupElement<T>
        {
            return Contains(parent, x => { });
        }

        /// <summary>
        /// Add an &lt;Contains>-Tag.
        /// </summary>
        /// <param name="parent">The extended <see cref="BaseCoreComparingGroupElement"/>.</param>
        /// <param name="action">Fluent configuration of the <see cref="Contains"/>.</param>
        /// <typeparam name="T">The concrete type that is extended.</typeparam>
        /// <returns><see cref="BaseCoreComparingGroupElement{T}"/>.</returns>
        public static T Contains<T>(this T parent, Action<Contains> action)
            where T : BaseCoreComparingGroupElement<T>
        {
            var contains = new Contains();
            action(contains);
            parent.Childs.Add(contains);
            return parent;
        }
    }
}
