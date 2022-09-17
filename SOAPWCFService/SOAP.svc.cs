using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SOAPWCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public double myBMI(double height, double weight)

        {
            double bmiscore = 0;
            bmiscore = (weight / (height * height)) * 703;
            return bmiscore;
        }

        public List<BodyMassIndex> myHealth(double height, double weight)

        {
            List<BodyMassIndex> BMI = new List<BodyMassIndex>();
            BodyMassIndex BMI1 = new BodyMassIndex();

            double bmiCalc = (weight / height / height) * 703;

            if (bmiCalc < 18)
            {
                BMI1.risk = "You are underweight (Blue)";
            }
            else if (bmiCalc >= 18 && bmiCalc < 25)
            {
                BMI1.risk = "You are normal (Green)";
            }
            else if (bmiCalc >= 25 && bmiCalc <= 30)
            {
                BMI1.risk = "You are pre-obese (Purple)";
            }
            else if (bmiCalc > 30)
            {
                BMI1.risk = "You are obese (Red)";
            }

            string array = "https://www.cdc.gov/healthyweight/assessing/bmi/index.html"
                            + "  https://www.nhlbi.nih.gov/health/educational/lose_wt/index.htm"
                            + "  https://www.ucsfhealth.org/education/body_mass_index_tool/";

            BMI1.bmi = bmiCalc;
            BMI1.more = array;

            BMI.Add(BMI1);
            return BMI;
        }
    }
}
