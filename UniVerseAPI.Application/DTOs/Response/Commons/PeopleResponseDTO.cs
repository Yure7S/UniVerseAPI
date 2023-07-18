﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UniVerseAPI.Infra.Data.Context
{
    public partial class PeopleResponseDTO
    {
 
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Cpf { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public AddresResponseDTO AddressEntity { get; set; }


        public PeopleResponseDTO(string fullName, DateTime birthDate, string cpf, string gender, string phone, string email, AddresResponseDTO addressEntity)
        {
            FullName = fullName;
            BirthDate = birthDate;
            Cpf = cpf;
            Gender = gender;
            Phone = phone;
            Email = email;
            AddressEntity = addressEntity;
        }

        public PeopleResponseDTO()
        {
            
        }
    }


}