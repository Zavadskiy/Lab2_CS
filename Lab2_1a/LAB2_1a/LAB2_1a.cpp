#include <iostream>
#include <bitset> // Для бітового представлення
#include <cstdlib> // Для української мови у консолі
using namespace std;


int multiply(int x, int y)
{
    int ansver = 0, count = 0;
    bitset<16> bs1(x);
    bitset<16> bs2(y);
    std::cout << "Перший множник у двійковій системі " << bs1 << endl;
    std::cout << "Друге множник  у двійковій системі " << bs2 << endl;
    std::cout << endl;
    while (y) // цикл множення
    {
        if (y % 2 == 1)
            ansver += x << count;
        bitset<16> bs0(ansver);
        std::cout << "Результат   = " << bs0 << endl;
        count++;
        y /= 2;
        bitset<16> bs1(x);
        bitset<16> bs2(y);
        std::cout << "Перший множник = " << bs1 << endl;
        std::cout << "Друге множник  = " << bs2 << endl;
        std::cout << endl;

    }
    return ansver;
}

int main()
{
    setlocale(LC_ALL, "Russian");
    system("chcp 1251");
    int x, y;
    std::cout << " Число перше = ";
    std::cin >> x;
    std::cout << " Число друге = ";
    std::cin >> y;
    cout << multiply(x, y) << endl;
    return 0;
}