﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;

namespace GuitarPlayers
{
    public abstract class NotifyPropertyChanged : INotifyPropertyChanged
    {
        private static readonly Dictionary<string, PropertyChangedEventArgs> eventArgCache;

        static NotifyPropertyChanged()
        {
            eventArgCache = new Dictionary<string, PropertyChangedEventArgs>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            var handler = this.PropertyChanged;
            if (null != handler)
            {
                PropertyChangedEventArgs args = GetPropertyChangedEventArgs(propertyName);
                handler(this, args);
            }
        }

        protected virtual void OnPropertyChanged<T>(Expression<Func<T>> expression)
        {
            var lambda = expression as LambdaExpression;

            if (null == lambda) return;

            var memberExpression = (lambda.Body is UnaryExpression) ? ((UnaryExpression)lambda.Body).Operand as MemberExpression : lambda.Body as MemberExpression;
            this.OnPropertyChanged(memberExpression != null ? memberExpression.Member.Name : string.Empty);
        }

        private static PropertyChangedEventArgs GetPropertyChangedEventArgs(string propertyName)
        {
            PropertyChangedEventArgs args;

            lock (typeof(NotifyPropertyChanged))
            {
                if (!eventArgCache.TryGetValue(propertyName, out args))
                {
                    eventArgCache.Add(propertyName, new PropertyChangedEventArgs(propertyName));
                }

                args = eventArgCache[propertyName];
            }

            return args;
        }
    }
}
