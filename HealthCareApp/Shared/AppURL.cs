﻿using System;
using System.Security.Principal;
using MyApp.Pages.PlaygroundPage;

namespace MyApp.Shared
{
    public class AppURL
    {
        public readonly string Home;
        public readonly string Dashboard;
        public readonly string About;

        public readonly string Admin;
        public readonly string AdminEmployees;
        public readonly string AdminDepartments;
        public readonly string AdminBarcodes;
        public readonly string AdminBarcodesMop;
        public readonly string AdminBarcodesChemical;

        public readonly string API;
        public readonly string APIGet;
        public readonly string APIPost;
        public readonly string APIPut;
        public readonly string APIDelete;

        public readonly string Identity;
        public readonly string IdentityAccount;
        public readonly string IdentityAccountManage;

        public readonly string Playground;
        public readonly string PlaygroundCard;
        public readonly string PlaygroundCardV3;
        public readonly string PlaygroundPageV3;
        public readonly string PlaygroundModal;
        public readonly string PlaygroundToast;
        public readonly string PlaygroundBadge;
        public readonly string PlaygroundSpinner;

        public readonly string Tasks;
        public readonly string TasksMopUsage;
        public readonly string TasksChemicalRecord;

        public AppURL()
        {
            Home = "/";
            Dashboard = "/dashboard";
            About = "/about";

            Admin = "/admin";
            AdminEmployees = $"{Admin}/employees";
            AdminDepartments = $"{Admin}/departments";
            AdminBarcodes = $"{Admin}/barcodes";
            AdminBarcodesMop = $"{AdminBarcodes}/mop";
            AdminBarcodesChemical = $"{AdminBarcodes}/chemical";

            API = "/api";
            APIGet = $"{API}/get";
            APIPost = $"{API}/post";
            APIPut = $"{API}/put";
            APIDelete = $"{API}/delete";

            Playground = "/playground";
            PlaygroundCard = $"{Playground}/card";
            PlaygroundCardV3 = $"{Playground}/card-v3";
            PlaygroundPageV3 = $"{Playground}/page-v3";
            PlaygroundModal = $"{Playground}/modal";
            PlaygroundToast = $"{Playground}/toast";
            PlaygroundBadge = $"{Playground}/badge";
            PlaygroundSpinner = $"{Playground}/spinner";

            Identity = "/Identity";
            IdentityAccount = $"{Identity}/Account";
            IdentityAccountManage = $"{IdentityAccount}/Manage-New";

            Tasks = "/tasks";
            TasksMopUsage = $"{Tasks}/mop-usage";
            TasksChemicalRecord = $"{Tasks}/chemical-record";
        }
    }
}
