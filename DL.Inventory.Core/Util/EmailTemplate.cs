using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DL.Inventory.Core.Util
{
    public class EmailTemplate
    {
       public static string ResetPassword(string username, string password)
        {
            var retorno = @"<html>
            <body>
                <div style = 'text-align: center; margin-bottom: 9px;'>
                     <img src = 'http://dev-loops.com/images/dl.png'>  
                </div>
                <div style = 'background-color:blueviolet'>
                        </br><h2 style = 'color: cornsilk; margin-left: 10px;'>Ol&aacute; "+ username +@"</h2></br></br>         
                        <h3 style = 'color: cornsilk; margin-left: 10px;'>Voc&ecirc; solicitou uma nova senha de acesso ao sistema.</h3>              
                        <h3 style = 'color: cornsilk; margin-left: 10px;'>Abaixo sua senha:</h3>                     
                        <h3 style = 'color: cornsilk; margin-left: 10px;'><strong>"+password+@"</strong></h3></br></br></br>             
                        <h3 style = 'color: cornsilk; margin-left: 10px;'>Obrigado!</h3></br>                             
                </div>
                <div style = 'text-align: center; margin-bottom: 9px; color: blueviolet;'>                              
                    <h4>@copyright DevLoops Software</h4>                                 
                </div>              
            </body>
          </html>";
           return retorno;
        }
    }
}