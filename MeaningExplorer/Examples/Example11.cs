﻿using Clifton.Meaning;

namespace MeaningExplorer.Examples.Example11
{
    class FirstName : IValueEntity { }
    class LastName : IValueEntity { }
    class EmployeeId : IValueEntity { }

    public class PersonNameContext : Context
    {
        public PersonNameContext()
        {
            Declare<FirstName>().OneAndOnlyOne();
            Declare<LastName>().OneAndOnlyOne();
        }
    }

    public class PersonContext : Context
    {
        public PersonContext()
        {
            Declare<PersonNameContext>().OneAndOnlyOne();
        }
    }

    class PersonNameRelationship : IRelationship { }
    class EmergencyContactRelationship : IRelationship { }

    class EmergencyContact : IEntity { }

    class BusinessName : IValueEntity { }

    public class BusinessContext : Context
    {
        public BusinessContext()
        {
            Declare<BusinessName>().OneAndOnlyOne();
        }
    }

    class EmployeeContext : Context
    {
        public EmployeeContext()
        {
            Declare<EmployeeId>().OneAndOnlyOne();
            AddAbstraction<EmployeeContext, PersonContext>("Employee Name").Coalesce();
        }
    }

    class Spouse : IEntity { }
    class Child : IEntity { }

    public class EmployeeContractContext : Context
    {
        public EmployeeContractContext()
        {
            Label = "Employee Contract";
            Declare<EmployeeContext>("Employee").OneAndOnlyOne();
            AddAbstraction<Spouse, PersonContext>("Spouse Name");
            AddAbstraction<Child, PersonContext>("Child Name");
        }
    }
}