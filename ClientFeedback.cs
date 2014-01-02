using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainForm
{
    class ClientFeedback
    {
        private static bool warningHasBeenSendt = false; 
        // Prevents constant warning messages when temperature stays outside of bounds
        private static bool errorHasBeenSendt = false; 
        // As above, but for program errors

        public static void determineNeedForWarning(decimal sensorValue)
            // Method called each timer tick in order to determine whether or not a warning should be sent
        {
            try
            {
                if (warningHasBeenSendt == false && Error.HasError == false)
                {
                    if (sensorValue > Properties.Settings.Default.tempMax || sensorValue < Properties.Settings.Default.tempMin)
                    {
                        // first time temperature is outside limits. need to send warning
                        sendWarning(sensorValue);
                        warningHasBeenSendt = true; 
                    }
                }
                if(errorHasBeenSendt == false)
                {
                    if (Error.HasError == true)
                    {
                        // An error has occured. Send warning
                        sendWarning(Database.getLastErrorMessage());
                        errorHasBeenSendt = true;
                    }
                }
                if (warningHasBeenSendt == true)
                {
                    if (sensorValue < Properties.Settings.Default.tempMax && sensorValue > Properties.Settings.Default.tempMin)
                    {
                        // temperature is back within limits. rearm the alarm
                        warningHasBeenSendt = false;
                    }
                }
                if (errorHasBeenSendt == true)
                {
                    if (Error.HasError == false)
                    {
                        // error has been magically resolved (exclamation mark clicked)
                        errorHasBeenSendt = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Error.WriteLog("ClientFeedback-determine warning", ex.Message, "");
            }
        }

        private static void sendWarning(decimal sensorValue)
        {
            // Method sends warning message if temperature is out of bounds
            try
            {
                // check if values are outside limits
                if (sensorValue > Properties.Settings.Default.tempMax)
                {
                    // temperature is too high
                    if (Properties.Settings.Default.warnMail == true) // send e-mail
                    {
                        Mail.sendMailToEntireContactsList("Temperature warning", "Temperature has exceeded the limit of: " +
                            Properties.Settings.Default.tempMax + " degrees\n" +
                            "Last temperature reading was: " + sensorValue + " degrees\n");
                    }
                    if (Properties.Settings.Default.warnSMS == true) // send SMS
                    {
                        SMS.sendSMSToEntireContactsList("Temperature warning", "Temperature has exceeded the limit of: " +
                            Properties.Settings.Default.tempMax + " degrees\n" +
                            "Last temperature reading was: " + sensorValue + " degrees\n");
                    }
                }
                if (sensorValue < Properties.Settings.Default.tempMin)
                {
                    // temperature is too low
                    if (Properties.Settings.Default.warnMail == true) // send mail
                    {
                        Mail.sendMailToEntireContactsList("Temperature warning", "Temperature is below the limit of: " +
                            Properties.Settings.Default.tempMin + " degrees\n" +
                            "Last temperature reading was: " + sensorValue + " degrees\n");
                    }
                    if (Properties.Settings.Default.warnSMS == true) // send SMS
                    {
                        SMS.sendSMSToEntireContactsList("Temperature warning", "Temperature is below the limit of: " +
                            Properties.Settings.Default.tempMin + " degrees\n" +
                            "Last temperature reading was: " + sensorValue + " degrees\n");
                    }
                }
            }
            catch (Exception ex)
            {
                Error.WriteLog("ClientFeedback-sendMessages", ex.Message, "");
            }
        }



        public static void sendWarning(string errormessage)
        {
            // Method sends an error message if an error has occured
            try
            {
                // Error occured
                if (Properties.Settings.Default.warnMail == true) // send mail
                {
                    Mail.sendMailToEntireContactsList("Error", "Last reported error was:\n " + errormessage);
                }
                if (Properties.Settings.Default.warnSMS == true) // send SMS
                {
                    SMS.sendSMSToEntireContactsList("Error", "An error has occured");
                }
            }
            catch (Exception)
            {
                // No code her to avoid infinite calling to self
            }
        }
    }
}
