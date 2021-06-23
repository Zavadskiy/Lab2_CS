#include <iostream>
#include <bitset>
#include <cstdlib>

using namespace std;

int division(int r, int d)
{
    int q = 0;
    d = d << 32;
    r = r << 1;
    for (int i = 0; i < 32; i++)
    {
        std::cout << i << endl;
        if (r <= d)
        {
            std::cout << "Дільник меньший за ділене" << endl;
            r = r - d;
            std::cout << "remainder << 1 " << endl;
            r = r << 1;
            std::cout << "quantient << 1 " << endl;
            q = q << 1;
            std::cout << "quantient | 1" << endl;
            q = q | 1;
        }
        else
        {
            std::cout << "Дільник більший за ділене" << endl;
            std::cout << "remainder << 1" << endl;
            r = r << 1;
            std::cout << "quantient << 1" << endl;
            q = q << 1;
        }
        bitset<64> bs1(r);
        bitset<32> bs2(d >> 32);
        bitset<32> bs3(q);
        std::cout << "Ділене  = " << bs1 << endl;
        std::cout << "Частка  = " << bs3 << endl;
        std::cout << "Дільник  = " << bs2 << endl;
        std::cout << endl;
    }
    return  q;
}
int main()
{
    setlocale(LC_ALL, "Russian");
    system("chcp 1251");
    int remainder, divisor;
    std::cout << " Ділене = ";
    std::cin >> remainder;
    std::cout << " Дільник = ";
    std::cin >> divisor;
    cout << division(remainder, divisor);
    return 0;
}