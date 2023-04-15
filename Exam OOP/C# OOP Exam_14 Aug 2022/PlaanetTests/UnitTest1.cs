using System.Reflection;
using PlanetWars;

namespace PlaanetTests
{
    public class Tests
    {
        private static readonly Assembly ProjectAssembly = typeof(StartUp).Assembly;

        [Test]
        public void CreatePlanet_AlreadyAddedPlanet()
        {
            var controller = CreateObjectInstance(GetType("Controller"));


            var planetArguments = new object[] { "PlanetOne", 200 };
            InvokeMethod(controller, "CreatePlanet", planetArguments);

            var validActualResult = InvokeMethod(controller, "CreatePlanet", planetArguments);

            var validExpectedResult = "Planet PlanetOne is already added!";

            Assert.AreEqual(validExpectedResult, validActualResult);
        }

        private static object InvokeMethod(object obj, string methodName, object[] parameters)
        {
            try
            {
                var result = obj.GetType()
                    .GetMethod(methodName)
                    .Invoke(obj, parameters);

                return result;
            }
            catch (TargetInvocationException e)
            {
                return e.InnerException.Message;
            }
        }

        private static object CreateObjectInstance(Type type, params object[] parameters)
        {
            try
            {
                var desiredConstructor = type.GetConstructors()
                    .FirstOrDefault(x => x.GetParameters().Any());

                if (desiredConstructor == null)
                {
                    return Activator.CreateInstance(type, parameters);
                }

                var instances = new List<object>();

                foreach (var parameterInfo in desiredConstructor.GetParameters())
                {
                    var currentInstance = Activator.CreateInstance(GetType(parameterInfo.Name.Substring(1)));

                    instances.Add(currentInstance);
                }

                return Activator.CreateInstance(type, instances.ToArray());
            }
            catch (TargetInvocationException e)
            {
                return e.InnerException.Message;
            }
        }

        private static Type GetType(string name)
        {
            var type = ProjectAssembly
                .GetTypes()
                .FirstOrDefault(t => t.Name.Contains(name));

            return type;
        }
    }
}