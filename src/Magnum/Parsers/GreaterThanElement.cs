// Copyright 2007-2008 The Apache Software Foundation.
//  
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use 
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed 
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace Magnum.Parsers
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Expressions;

	public class GreaterThanElement :
		IRangeElement
	{
		public string Begin { get; private set; }

		public GreaterThanElement(string begin)
		{
			Begin = begin;
		}

		public override string ToString()
		{
			return string.Format("{0}-", Begin);
		}

		public bool Includes(IRangeElement element)
		{
			if (element == null)
				return false;

			if (element is StartsWithElement)
				return Includes((StartsWithElement) element);

			if (element is RangeElement)
				return Includes((RangeElement) element);

			return false;
		}

		public IEnumerable<T> Where<T>(IEnumerable<T> elements, Expression<Func<T, string>> memberExpression)
		{
			Expression<Func<T, bool>> expression = memberExpression.ToCompareToExpression(Begin, ExpressionType.GreaterThanOrEqual);

			return elements.Where(expression.Compile());
		}

		public IQueryable<T> Where<T>(IQueryable<T> elements, Expression<Func<T, string>> memberExpression)
		{
			Expression<Func<T, bool>> expression = memberExpression.ToCompareToExpression(Begin, ExpressionType.GreaterThanOrEqual);

			return elements.Where(expression);
		}

		private bool Includes(StartsWithElement element)
		{
			if (element.Start.CompareTo(Begin) >= 0)
				return true;

			return false;
		}

		private bool Includes(RangeElement element)
		{
			if (element.Begin.CompareTo(Begin) >= 0)
				return true;

			return false;
		}

		public bool Equals(GreaterThanElement other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return Equals(other.Begin, Begin);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof (GreaterThanElement)) return false;
			return Equals((GreaterThanElement) obj);
		}

		public override int GetHashCode()
		{
			return (Begin != null ? Begin.GetHashCode() : 0);
		}
	}
}