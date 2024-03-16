﻿/************************************************************************************************************
*  COPYRIGHT BY ZIGGY RAFIQ (ZAHEER RAFIQ)
*  LinkedIn Profile URL Address: https://www.linkedin.com/in/ziggyrafiq/ 
*
*  System   :  	ZR Demo Project 01 - Book Api
*  Date     :  	20/09/2022
*  Author   :  	Ziggy Rafiq (https://www.ziggyrafiq.com)
*  Notes    :  	
*  Reminder :	PLEASE DO NOT CHANGE OR REMOVE AUTHOR NAME.
*
************************************************************************************************************/
namespace ZR.Business.Services.Interfaces
{
    public interface ILoggerManagerService
    {

        void LogInfo(string message);
        void LogWarn(string message);
        void LogDebug(string message);
        void LogError(string message);


    }
}
