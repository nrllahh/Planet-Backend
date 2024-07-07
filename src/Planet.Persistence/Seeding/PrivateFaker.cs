using Bogus;
using System.Reflection;
using System.Runtime.CompilerServices;
using Binder = Bogus.Binder;

namespace Planet.Persistence.Seeding
{
    public class PrivateBinder : Binder
    {
        public override Dictionary<string, MemberInfo> GetMembers(Type t)
        {
            var members = base.GetMembers(t);

            var privateBindingFlags = BindingFlags.Instance | BindingFlags.NonPublic;
            var allPrivateMembers = t.GetMembers(privateBindingFlags)
                                     .OfType<FieldInfo>()
                                     .Where(fi => fi.IsPrivate)
                                     .Where(fi => !fi.GetCustomAttributes(typeof(CompilerGeneratedAttribute)).Any())
                                     .ToArray();

            foreach (var privateField in allPrivateMembers)
            {
                members.Add(privateField.Name, privateField);
            }
            return members;
        }
    }
    internal class PrivateFaker<T> : Faker<T> where T : class
    {
        public PrivateFaker(string locale) : base(locale, binder: new PrivateBinder())
        {
        }

        public PrivateFaker<T> UsePrivateConstructor()
        {
            return base.CustomInstantiator(f => Activator.CreateInstance(typeof(T), nonPublic: true) as T)
               as PrivateFaker<T>;
        }

        public PrivateFaker<T> RuleForPrivate<TProperty>(string propertyName, Func<Faker, TProperty> setter)
        {
            base.RuleFor(propertyName, setter);
            return this;
        }

    }
}
