﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace _0425_실습
{
    /// <summary>
    /// MemberService의 요약 설명입니다.
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // ASP.NET AJAX를 사용하여 스크립트에서 이 웹 서비스를 호출하려면 다음 줄의 주석 처리를 제거합니다. 
    // [System.Web.Script.Services.ScriptService]
    public class MemberService : System.Web.Services.WebService, IMemberService
    {

        private MemberService1 member = new MemberService1();


        [WebMethod]
        public bool InsertMember(string name, string phone)
        {
            return member.InsertMember(name, phone);
        }

        [WebMethod]
        public Member SelectMember(string name)
        {
            return member.SelectMember(name);
        }

        [WebMethod]
        public List<Member> SelectAllMember()
        {
            return member.SelectAllMember();
        }
    }
}
