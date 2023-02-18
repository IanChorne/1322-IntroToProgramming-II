using System;
using System.Collections.Generic;

namespace _1322_Assignment_5
{
    class Program
    {
        static void Main(string[] args)
        {
            List<InsurancePolicy> policies = new List<InsurancePolicy>();
            int choice = 0;
            do
            {
                Console.WriteLine("1 - Create Health Insurance Policy\n2 - Create Term-Life Insurance Policy\n3 - Exit");
                choice = Int32.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter name of policy holder: ");
                        string ph = Console.ReadLine();
                        Console.WriteLine("Enter deductible amount: ");
                        double d = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Enter co-payment amount: ");
                        double copay = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Enter total out-of-pocket amount: ");
                        double oop = Convert.ToDouble(Console.ReadLine());

                        HealthInsurancePolicy hPolicy = new HealthInsurancePolicy(ph, d, copay, oop);
                        policies.Add(hPolicy);
                        break;
                    case 2:
                        Console.WriteLine("Enter name of policy holder: ");
                        string pH = Console.ReadLine();
                        Console.WriteLine("Enter name of beneficiary: ");
                        string b = Console.ReadLine();
                        Console.WriteLine("Enter number of years in term: ");
                        int term = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Enter amount of payout: ");
                        double payout = Convert.ToDouble(Console.ReadLine());

                        TermLifeInsuracePolicy tlPolicy = new TermLifeInsuracePolicy(pH, b, term, payout);
                        policies.Add(tlPolicy);
                        break;
                    case 3:
                        foreach(InsurancePolicy x in policies)
                        {
                            Console.WriteLine(x);
                        }
                        break;
                }

                

                if (choice > 3 || choice < 1)
                {
                    Console.WriteLine("Error: Please Enter Valid Input");
                }
            }
            while (choice > 0 && choice < 4);
            
        }
    }

    interface Deductible
    {
        public abstract bool hasMetDeductible();

        public abstract bool hasMetTotalOutOfPocket();
    }

    abstract class InsurancePolicy
    {
        private string policyHolder;
        private int policyNumber;
        private static int numberOfPolicies = 0;
        private double premium = 0.0;

        public InsurancePolicy() { }
        public InsurancePolicy(string ph)
        {
            policyHolder = ph;
            policyNumber = ++numberOfPolicies;
        }

        public abstract void selectPolicyCoverage();
        public abstract void calculatePremium();

        public override string ToString()
        {
            return policyHolder + "\t" + policyNumber + ". ";  //which string in sample output? 
        }

        //Getters/Setters
        public void setPolicyHolder(string n) { policyHolder = n; }
        public string getPolicyHolder() { return policyHolder; }
        public void setPolicyNumber(int i) { policyNumber = i; }
        public int getPolicyNumber() { return policyNumber; }
        //public void setNumOfPolicies() { }
        public void setPremium(double a) { premium = a; }
        public double getPremium() { return premium; }


    }

    class TermLifeInsuracePolicy : InsurancePolicy
    {
        private string beneficiary;
        private int term;
        private double termPayout;

        public TermLifeInsuracePolicy() { }
        public TermLifeInsuracePolicy(string ph, string b, int t, double tp) : base(ph)
        {
            beneficiary = b;
            term = t;
            termPayout = tp;
        }

        public override void selectPolicyCoverage()
        {
            Console.WriteLine("Selecting policy coverages"); //finish output
        }

        public override void calculatePremium() //how to print a message in an abstract class?
        {
            Console.WriteLine("Calculating and updating premium");
        }

        public override string ToString()
        {
            return getPolicyHolder() + "\t" + getPolicyNumber() + ","; //figure out which string to return
        }

        //getters/setters
        public void setBeneficiaary(string n) { beneficiary = n; }
        public string getBeneficiary() { return beneficiary; }
        public void setTerm(int i) { term = i; }
        public int getTerm() { return term; }
        public void setTermPayout(double a) { termPayout = a; }
        public double getTermPayout() { return termPayout; }
    }

    class HealthInsurancePolicy : InsurancePolicy, Deductible 
    {
        private double deductibleLimit;
        private double totalDeductiblePaid;
        private double coPayment;
        private double totalCoPaymentPaid = 0;
        private double totalOutOfPocket;

        public HealthInsurancePolicy() { }
        public HealthInsurancePolicy(string ph, double dL, double coP, double tOp) : base(ph)
        {
            deductibleLimit = dL;
            coPayment = coP;
            totalOutOfPocket = tOp;
        }

        public override void calculatePremium() 
        {
            Console.WriteLine("Calculating and updating premium");
        } 

        public bool hasMetDeductible()
        {
            bool hasMetDeductible;
            if(totalDeductiblePaid >= deductibleLimit)
            {
                hasMetDeductible = true; //how to make this true?
                return hasMetDeductible;
            }
            else
            {
                hasMetDeductible = false;
                return hasMetDeductible;
            }
        }

        public override void selectPolicyCoverage()
        {
            Console.WriteLine("Selecting policy coverages"); //finish output
        }

        public bool hasMetTotalOutOfPocket()
        {
            bool hasMetTotalOutOfPocket;
            if(totalDeductiblePaid + totalCoPaymentPaid >= totalOutOfPocket)
            {
                hasMetTotalOutOfPocket = true;
                return hasMetTotalOutOfPocket;
            }
            else
            {
                hasMetTotalOutOfPocket = false;
                return hasMetTotalOutOfPocket;
            }
        }

        public override string ToString()
        {
            return getPolicyHolder() +  ",\t" + getPolicyNumber() + ", Has met deductible: " + hasMetDeductible() + ", Has met total out of pocket: " + hasMetTotalOutOfPocket(); //print right label
        }

        //getters/setters
        public void setDeductibleLimit(double a) { deductibleLimit = a; }
        public double getDeductibleLimit() { return deductibleLimit; }
        public void setTotalDeductiblePaid(double a) { totalDeductiblePaid = a; }
        public double getTotalDeductiblePaid() { return totalDeductiblePaid; }
        public void setCoPayment(double a) { coPayment = a; }
        public double getCoPayment() { return coPayment; }
        public void setTotalCoPaymentPaid(double a) { totalCoPaymentPaid = a; }
        public double getTotalCoPaymentPaid() { return totalCoPaymentPaid; }
        public void setTotalOutOfPocket(double a) { totalOutOfPocket = a; }
        public double getTotalOutOfPocket() { return totalOutOfPocket; }
    }
}
