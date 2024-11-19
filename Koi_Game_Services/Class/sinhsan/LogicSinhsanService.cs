using Koi_Game_Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi_Game_Services.Class.sinhsan
{
    public class LogicSinhsanService : ILogicSinhsanService
    {
        public async Task<int> GetIdKoi_SauSinh(string color_1, string color_2)
        {
            var random = new Random();
            //int randomNum = (int)Math.Pow(random.NextDouble(), 2) * 100;
            // int randomNum = random.Next(1, 101); // Tạo số ngẫu nhiên từ 1 đến 100
            int randomNum = (int)(Math.Pow(random.NextDouble(), 0.5) * 100) + 1;
            Console.WriteLine($"Random number generated: {randomNum}");                              // random phan phoi binh phuong tu 1 dens 100 
                                                                                                     // lai 2 con cung mau don gian red, yellow, blue 
            if (color_1 == color_2)
            {
                if (color_1 == "Red") return 1; //id koi red
                else if (color_1 == "Blue") return 2; //id koi blue
                else if (color_1 == "Yellow") return 3;// id koi yellow
                else if (color_1 == "Purple") return 4;// id  koi purple
                else if (color_1 == "Orange") return 5;// id koi cam
                else if (color_1 == "Green") return 6;// id koi green 
                // 2 con cau voong lai thi se co co hoi ra 2 con ca hiem nhat game
                else if (color_1 == "Rainbow")
                {
                    if (randomNum <= 1) //1% ra den
                    {
                        return 8; //id koi den 
                    }
                    else if (randomNum <= 2)// 1% ra trang
                    {
                        return 9; //id  koi trang
                    }
                    // 98% ra lai ca don sac mac dinh
                    else if (randomNum <= 35) return 1;
                    else if (randomNum <= 68) return 2;
                    else return 3;
                }
                // 2 ca cung mau trangw hoac den, dem di lai tao se ra con cau vong 
                else if (color_1 == "Black") return 7;
                else return 7;
            }
            else
            {
                //lai 2 con khac mau don gian red, yellow, blue
                if (color_1 == "Red" && color_2 == "Blue" || color_1 == "Blue" && color_2 == "Red")
                {
                    if (randomNum <= 20) return 4;//id koi pruple 20% la ra mauu tim
                    else if (randomNum <= 70) return 1;
                    else return 2;
                }
                else if (color_1 == "Red" && color_2 == "Yellow" || color_1 == "Yellow" && color_2 == "Red")
                {
                    if (randomNum <= 20) return 5;//id koi orange 20% ra mau cam
                    else if (randomNum <= 90) return 1;
                    else return 3;
                }
                else if (color_1 == "Yellow" && color_2 == "Blue" || color_1 == "Blue" && color_2 == "Yellow")
                {
                    if (randomNum <= 40) return 6;//id koi green 40% ra mau xanh la
                    else if (randomNum <= 80) return 2;
                    else return 3;
                }
                // lai ca khac mau tim, cam, xanh la
                else if (color_1 == "Purple" && color_2 == "Orange" || color_1 == "Orange" && color_2 == "Purple")
                {
                    if (randomNum <= 5) return 7;//5% ra ca cau vong 
                    else if (randomNum <= 35) return 1;// 30% ra ca do
                    else if (randomNum <= 55) return 2;// 20% ra ca blue
                    else if (randomNum <= 60) return 3;// 15% ra ca vang
                    else if (randomNum <= 70) return 6;// 10% ra ca xanh la
                    else if (randomNum <= 85) return 4;// 15% ra ca tim
                    else return 5;// 15% ra ca cam
                }
                else if (color_1 == "Purple" && color_2 == "Green" || color_1 == "Green" && color_2 == "Purple")
                {
                    if (randomNum <= 5) return 7;//5% ra ca cau vong 
                    else if (randomNum <= 40) return 2;// 35% ra ca blue
                    else if (randomNum <= 45) return 3;// 5% ra ca vang
                    else if (randomNum <= 60) return 1;// 15% ra ca do
                    else if (randomNum <= 75) return 6;// 15% ra ca xanh la
                    else if (randomNum <= 90) return 4;// 15% ra ca tim
                    else return 5;// 10% ra ca cam
                }
                else if (color_1 == "Green" && color_2 == "Orange" || color_1 == "Orange" && color_2 == "Green")
                {
                    if (randomNum <= 5) return 7;//5% ra ca cau vong 
                    else if (randomNum <= 25) return 3;// 20% vang
                    else if (randomNum <= 40) return 2;// 15% blue
                    else if (randomNum <= 60) return 1;// 20% do
                    else if (randomNum <= 75) return 5;// 15% cam
                    else if (randomNum <= 90) return 6;// 15% green
                    else return 4;//10% tim
                }
                // lai giua 3 mau :do, bllue, vang voi 3 mau:  tim, cam, green
                else if (color_1 == "Purple" && color_2 == "Red" || color_1 == "Red" && color_2 == "Purple")
                {
                    if (randomNum <= 80) return 1;
                    else if (randomNum <= 93) return 2;
                    else return 4;
                }
                else if (color_1 == "Orange" && color_2 == "Red" || color_1 == "Red" && color_2 == "Orange")
                {
                    if (randomNum <= 80) return 1;
                    else if (randomNum <= 90) return 3;
                    else return 5;
                }
                else if (color_1 == "Green" && color_2 == "Red" || color_1 == "Red" && color_2 == "Green")
                {
                    if (randomNum <= 3) return 7;
                    else if (randomNum <= 63) return 1;
                    else if (randomNum <= 83) return 2;
                    else if (randomNum <= 90) return 3;
                    else if (randomNum <= 95) return 4;
                    else return 5;
                }
                else if (color_1 == "Purple" && color_2 == "Blue" || color_1 == "Blue" && color_2 == "Purple")
                {
                    if (randomNum <= 60) return 2;
                    else if (randomNum <= 95) return 1;
                    else return 4;
                }
                else if (color_1 == "Blue" && color_2 == "Orange" || color_1 == "Orange" && color_2 == "Blue")
                {
                    if (randomNum <= 4) return 7;
                    else if (randomNum <= 54) return 2;
                    else if (randomNum <= 74) return 1;
                    else if (randomNum <= 84) return 3;
                    else if (randomNum <= 90) return 6;
                    else return 4;
                }
                else if (color_1 == "Blue" && color_2 == "Green" || color_1 == "Green" && color_2 == "Blue")
                {
                    if (randomNum <= 80) return 2;
                    else if (randomNum <= 85) return 3;
                    else return 6;
                }
                else if (color_1 == "Purple" && color_2 == "Yellow" || color_1 == "Yellow" && color_2 == "Purple")
                {
                    if (randomNum <= 3) return 7;
                    else if (randomNum <= 43) return 3;
                    else if (randomNum <= 68) return 1;
                    else if (randomNum <= 88) return 2;
                    else if (randomNum <= 95) return 5;
                    else return 6;
                }
                else if (color_1 == "Yellow" && color_2 == "Orange" || color_1 == "Orange" && color_2 == "Yellow")
                {
                    if (randomNum <= 50) return 3;
                    else if (randomNum <= 9) return 1;
                    else return 5;
                }
                else if (color_1 == "Yellow" && color_2 == "Green" || color_1 == "Green" && color_2 == "Yellow")
                {
                    if (randomNum <= 50) return 3;
                    else if (randomNum <= 90) return 2;
                    else return 6;
                }
                //den||trang + color = mauf ddos lonws hown nos 1 bacja 
                else if (color_1 == "Black")
                {
                    if (color_2 == "Red") return 4;// do len tim
                    else if (color_2 == "Blue") return 6;// blue len green
                    else if (color_2 == "Yellow") return 5;// vang len cam
                    // cac truong hop con lai ra chinh no
                    else if (color_2 == "Purple") return 4;
                    else if (color_2 == "Orange") return 5;
                    else if (color_2 == "Green") return 6;
                    else if (color_2 == "Rainbow") return 7;
                    //den + trang = trang||den||rainbow
                    else
                    {
                        // tir leej 1%den, 1% trang
                        if (randomNum <= 1) return 8;
                        else if (randomNum <= 2) return 9;
                        else return 7;
                    }
                }
                else if (color_1 == "White")
                {
                    if (color_2 == "Red") return 4;
                    else if (color_2 == "Blue") return 6;
                    else if (color_2 == "Yellow") return 5;
                    else if (color_2 == "Purple") return 4;
                    else if (color_2 == "Orange") return 5;
                    else if (color_2 == "Green") return 6;
                    else if (color_2 == "Rainbow") return 7;
                    else
                    {
                        if (randomNum <= 1) return 8;
                        else if (randomNum <= 2) return 9;
                        else return 7;
                    }
                }
                else if (color_2 == "Black")
                {
                    if (color_1 == "Red") return 1;
                    else if (color_1 == "Blue") return 2;
                    else if (color_1 == "Yellow") return 3;
                    else if (color_1 == "Purple") return 4;
                    else if (color_1 == "Orange") return 5;
                    else if (color_1 == "Green") return 6;
                    else return 7;
                    /*
                    else
                    {
                        if (randomNum <= 1) return 8;
                        else if (randomNum <= 2) return 9;
                        else return 7;
                    }*/
                }
                else if (color_2 == "white")
                {
                    if (color_1 == "Red") return 1;
                    else if (color_1 == "Blue") return 2;
                    else if (color_1 == "Yellow") return 3;
                    else if (color_1 == "Purple") return 4;
                    else if (color_1 == "Orange") return 5;
                    else if (color_1 == "Green") return 6;
                    else return 7;
                    /*
                    else
                    {
                        if (randomNum <= 1) return 8;
                        else if (randomNum <= 2) return 9;
                        else return 7;
                    }*/
                }
                // rainbow + mau gi o 6 mau dau tien se ra i het mau do 
                else if (color_1 == "Rainbow")
                {
                    if (color_2 == "Red") return 1;
                    else if (color_2 == "Blue") return 2;
                    else if (color_2 == "Yellow") return 3;
                    else if (color_2 == "Purple") return 4;
                    else if (color_2 == "Orange") return 5;
                    else return 6;

                }
                else
                {
                    if (color_1 == "Red") return 1;
                    else if (color_1 == "Blue") return 2;
                    else if (color_1 == "Yellow") return 3;
                    else if (color_1 == "Purple") return 4;
                    else if (color_1 == "Orange") return 5;
                    else return 6;
                }
            }
        }
    }
}
