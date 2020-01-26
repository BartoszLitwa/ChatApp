﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Core
{
    /// <summary>
    /// A helper for expressions
    /// </summary>
    public static class ExpressionHelpers
    {
        /// <summary>
        /// Compiles an expression and gets the function return value
        /// </summary>
        /// <typeparam name="T">The type of return value</typeparam>
        /// <param name="lamba">The expression to compile</param>
        /// <returns></returns>
        public static T GetPropertyValue<T>(this Expression<Func<T>> lamba) => lamba.Compile().Invoke();

        /// <summary>
        /// Compiles an expression and gets the function return value
        /// </summary>
        /// <typeparam name="T">The type of return value</typeparam>
        /// <typeparam name="In">The input into the expression</typeparam>
        /// <param name="lamba">The expression to compile</param>
        /// <returns></returns>
        public static T GetPropertyValue<In, T>(this Expression<Func<In, T>> lamba, In input) => lamba.Compile().Invoke(input);

        /// <summary>
        /// Sets the underlying properties value to given value
        /// from an expression that contains the property
        /// </summary>
        /// <typeparam name="T">The type of to set</typeparam>
        /// <param name="lamba">The expression</param>
        /// <param name="value">The value to set the property to</param>
        public static void SetPropertyValue<T>(this Expression<Func<T>> lamba, T value)
        {
            //Converts a lambda () => some.Property to some.Property
            var expression = (lamba as LambdaExpression).Body as MemberExpression;

            // Get the property infromation so we can set it
            var propertyInfo = (PropertyInfo)expression.Member;
            var target = Expression.Lambda(expression.Expression).Compile().DynamicInvoke();

            // Set the property value
            propertyInfo.SetValue(target, value);
        }

        /// <summary>
        /// Sets the underlying properties value to given value
        /// from an expression that contains the property
        /// </summary>
        /// <typeparam name="T">The type of to set</typeparam>
        /// <typeparam name="In">The input into the expression</typeparam>
        /// <param name="lamba">The expression</param>
        /// <param name="value">The value to set the property to</param>
        public static void SetPropertyValue<In, T>(this Expression<Func<In, T>> lamba, T value, In input)
        {
            //Converts a lambda () => some.Property to some.Property
            var expression = (lamba as LambdaExpression).Body as MemberExpression;

            // Get the property infromation so we can set it
            var propertyInfo = (PropertyInfo)expression.Member;

            // Set the property value
            propertyInfo.SetValue(input, value);
        }
    }
}
