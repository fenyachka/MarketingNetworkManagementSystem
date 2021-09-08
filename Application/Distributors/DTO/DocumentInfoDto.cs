﻿using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Distributors.DTO
{
     public class DocumentInfoDto
    {
        public DocumentType DocumentType { get; set; }
        public string Seria { get; set; }
        public string Number { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string PrivateNumber { get; set; }
        public string IssueOrganization { get; set; }
    }
}
