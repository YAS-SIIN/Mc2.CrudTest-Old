using System.Text.RegularExpressions;
 
using Microsoft.Extensions.DependencyInjection;
using PhoneNumbers;

namespace Mc2.CrudTest.Presentation.Domain.Common
{     
public static class ValidationCheck
{
 
    public static bool IsValidPhone(this ulong phoneNumber)
    {

        PhoneNumberUtil pnuCheck = PhoneNumberUtil.GetInstance();
        try
        {
            PhoneNumber numberProto = pnuCheck.Parse(phoneNumber.ToString(), "IR");
            bool validate = pnuCheck.IsValidNumber(numberProto);
           
            return validate;
        }
        catch (NumberParseException ex)
        {
            return false;
        }
    }
    
    public static bool IsValidBankAccountNumber(this string bankAccountNumber)
    {
       if (bankAccountNumber.Replace("-","").Length != 16)  return false;  
       
        string[] ban = bankAccountNumber.Split('-');
      
        for (int i = 0; i < ban.Length; i++)
        {
            if (ban[i].Length != 4) return false;                        
        }

        return true;
    }
}
}