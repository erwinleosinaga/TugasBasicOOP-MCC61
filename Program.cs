using System;

namespace task_oop
{
    class Program:Belanja
    {
        static void Main(string[] args)
        {
            string[] barang = new string[20];
            int[] hrg = new int[20];
            int[] jml = new int[20];
            int[] tot = new int[20];

            int i, n, total = 0, bayar, menu;
            bool program = true;

            Transaksi transaksi = new Transaksi();
            Belanja belanja = new Belanja();

            while (program)
            {

                Console.Clear();
                mainMenu();
                menu = int.Parse(Console.ReadLine());

                switch (menu)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Masukkan jumlah uang yang ingin di top up");
                        int top_up = int.Parse(Console.ReadLine());
                        transaksi.tambah_saldo(top_up);
                        wait();
                        break;

                    case 2:
                        Console.Clear();
                        Console.Write("Masukan Jumlah barang yang di beli =  ");
                        n = int.Parse(Console.ReadLine());

                        for (i = 1; i <= n; i++)
                        {
                            Console.WriteLine("Masukan data barang ke-" + i);
                            Console.Write("\t Masukan nama barang = ");
                            barang[i] = Console.ReadLine();
                            Console.Write("\tMasukan harga barang = ");
                            hrg[i] = int.Parse(Console.ReadLine());
                            Console.Write("\tMasukan jumlah barang = ");
                            jml[i] = int.Parse(Console.ReadLine());
                            tot[i] = hrg[i] * jml[i];
                            total += tot[i];
                        }
                        Console.Clear();
                        Console.WriteLine("=======================================");
                        Console.WriteLine("   Kasir Swalayan    ");
                        Console.WriteLine("========================================");
                        Console.WriteLine(" No | Nama Barang \tHarga \tJumlah Total  ");
                        Console.WriteLine("---------------------------------------");
                        for (i = 1; i <= n; i++)
                        {
                            Console.WriteLine(i + "   " + barang[i] + "\t" + hrg[i] + "\t" + jml[i] + "\t" + tot[i]);
                        }
                        Console.WriteLine("=======================================");
                        Console.WriteLine("Total Harga Barang = " + total);

                     

                        transaksi.jumlah_discount = transaksi.setDiscount(total);
                        Console.WriteLine("Jumlah Total Discount = " + transaksi.jumlah_discount);

                        double total_barang_discount = total - transaksi.jumlah_discount;
                        Console.WriteLine("Jumlah Yang Harus Dibayar = " + total_barang_discount);

                        do
                        {

                            if (transaksi.saldo < total_barang_discount)
                            {
                                Console.WriteLine("Maaf, Saldo Anda Kurang  Silahkan Top Up!!");
                                Console.WriteLine("-------------------------");
                                total = 0;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Sisa saldo anda = " + (transaksi.saldo - total_barang_discount));
                                transaksi.saldo -= total_barang_discount;

                                Console.WriteLine("==============================================");
                                Console.WriteLine("          TERIMA KASIH  SUDAH BERBELANJA          ");
                                
                                total = 0;
                            }

                        } while (transaksi.saldo < total_barang_discount);


                        wait();
                        break;

                    case 3:
                        Console.Clear();
                        transaksi.tampil_saldo();
                        wait();
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Pilihan Tidak Tersedia");
                        wait();
                        break;
                }

            }
        }


       
       

        
    }

    public class Belanja:Transaksi{
    public static void wait()
        {
            Console.WriteLine("Tekan Enter Untuk Melanjutkan");
            Console.ReadLine();
        }

     public static void mainMenu()
        {
            Console.WriteLine("Kasir Swalayan Maju Bersama");

            Console.WriteLine("Pilih Menu");
            Console.WriteLine("1. Top Up");
            Console.WriteLine("2. Belanja");
            Console.WriteLine("3. Cek Saldo");
            Console.WriteLine("=============================================");

            Console.Write("Pilih Menu : ");
        }

    }

    public class Transaksi {
      
        public double saldo = 0;
        public double jumlah_discount = 0;
        public void tambah_saldo(double value)
        {
            saldo += value;
           
        }

        public void tampil_saldo()
        {
            Console.WriteLine("Saldo Anda Sekarang Adalah : {0}", saldo);
        }
        public Transaksi()
        {
            jumlah_discount = 0;
        } 
        public Transaksi(double value) {
            jumlah_discount = value;
        }

        public double setDiscount(double value)
        {
           if (value >= 1000000)
            {
                return value * 0.1;
            }
            else if (value >= 500000)
            {
                return value * 0.05;
            }
            else if (value >= 200000)
            {
                return value * 0.02;
            }
            else if (value >= 100000)
            {
                return value * 0.01;
            }
            else
            {
                return 0;
            }
        }

        
    }
}
