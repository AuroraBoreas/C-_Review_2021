using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Collections.Generic;
using System.Collections;

namespace DataParallelism
{
    // public partial class MainWindow: Window // version 0
    // {
    //     public MainWindow()
    //     {
    //         InitializeComponent();
    //     }

    //     private void cmdCancel_Click(object sender, EventArgs e)
    //     {
    //         // this will be updated shortly
    //     }

    //     private void cmdProcess_Click(object sender, EventArgs e)
    //     {
    //         ProcessFiles();
    //     }

    //     private void ProcessFiles()
    //     {
    //         string[] files = Directory.GetFiles(@".\TestPictures", "*.jpg", SearchOption.AllDirectories);
    //         string newDir = @".\ModifiedPictures";

    //         Directory.CreateDirectory(newDir);

    //         // process the image data in a blocking manner
    //         foreach(string currentFile in files)
    //         {
    //             string filename = Path.GetFileName(currentFile);

    //             using(Bitmap bitmap = new Bitmap(currentFile))
    //             {
    //                 bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
    //                 bitmap.Save(Path.Combine(newDir, filename));

    //                 this.Title = $"Processing {filename} on thread {Thread.CurrentThread.ManagedThreadId}";
    //             }
    //         }
    //     }
    // }
    // public partial class MainWindow: Window // version 1
    // {
    //     public MainWindow()
    //     {
    //         InitializeComponent();
    //     }

    //     private void cmdCancel_Click(object sender, EventArgs e)
    //     {
    //         // this will be updated shortly
    //     }

    //     private void cmdProcess_Click(object sender, EventArgs e)
    //     {
    //         ProcessFiles();
    //     }

    //     private void ProcessFiles()
    //     {
    //         string[] files = Directory.GetFiles(@".\TestPictures", "*.jpg", SearchOption.AllDirectories);
    //         string newDir = @".\ModifiedPictures";

    //         Directory.CreateDirectory(newDir);

    //         // process the image data in a blocking manner
    //         Parallel.ForEach(files, currentFile =>
    //             {
    //                 string filename = Path.GetFileName(currentFile);

    //                 using(Bitmap bitmap = new Bitmap(currentFile))
    //                 {
    //                     bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
    //                     bitmap.Save(Path.Combine(newDir, filename));

    //                     // this.Title = $"Processing {filename} on thread {Thread.CurrentThread.ManagedThreadId}";
    //                 }
    //             }
    //         );
    //     }
    // }
    public partial class MainWindow: Window // version 2
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            // this will be updated shortly
        }

        private void cmdProcess_Click(object sender, EventArgs e)
        {
            ProcessFiles();
        }

        private void ProcessFiles()
        {
            string[] files = Directory.GetFiles(@".\TestPictures", "*.jpg", SearchOption.AllDirectories);
            string newDir = @".\ModifiedPictures";

            Directory.CreateDirectory(newDir);

            // process the image data in a blocking manner
            Parallel.ForEach(files, currentFile =>
                {
                    string filename = Path.GetFileName(currentFile);

                    using(Bitmap bitmap = new Bitmap(currentFile))
                    {
                        bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        bitmap.Save(Path.Combine(newDir, filename));

                        // this.Title = $"Processing {filename} on thread {Thread.CurrentThread.ManagedThreadId}";
                        this.Dispatcher.Invoke((Action)delegate
                            {
                                Title = $"Processing {filename} on thread {Thread.CurrentThread.ManagedThreadId}";
                            }
                        );
                    }
                }
            );
        }
    }

    static CancellationTokenSource cancelToken = new CancellationTokenSource();


    class Program
    {
        static int Main(string[] args)
        {
            //
            {
                // see class MainWindow version 0
                // see class MainWindow version 1
                // see class MainWindow version 2
            }

            // handling cancellation request
            {
                /*

                + how
                    >> Parallel.For() an Parallel.ForEach() methods both support cancellation through the use of "cancellation tokens"

                */

            }

            // parallel LINQ queries(PLINQ)
            {
                /*

                + select members of the ParallelEnumerable class
                    - AsParallel()

                    - WithCancellation()
                    - WithDegreeOfParallelism()

                    - ForAll()


                */
                PLINQ();

                // cancel a PLINQ query
                PLINQ2();
            }



            return 0;
        }

        private static void ProcessIntData()
        {
            int[] source = Enumerable.Range(1, 10_000_000).ToArray();
            int[] modThreeIsZero = (
                from num in source
                where (num % 3 == 0)
                orderby num descending
                select num
            ).ToArray();

            System.Console.WriteLine($"Found {modThreeIsZero.Count()} numbers that match query!");
        }

        private static void PLINQ()
        {
            System.Console.WriteLine("start any key to start processing");
            Console.ReadLine();

            System.Console.WriteLine("processing");
            Task.Factory.StartNew(()=> ProcessIntData);
            Console.ReadLine();

        }

        private static void ProcessIntData2()
        {
            int[] source = Enumerable.Range(1, 10_000_000).ToArray();
            int[] modThreeIsZero = null;

            try
            {
                modThreeIsZero = (
                    from num in source.AsParallel().WithCancellation(CancellationToken.Token)
                    where num % 3 == 0
                    orderby num descending
                    select num).ToArray();
                System.Console.WriteLine();
                System.Console.WriteLine($"Found {modThreeIsZero.Count()} numbers that match query!");
            }
            catch (OperationCanceledException ex)
            {
                System.Console.WriteLine(ex.Message);
            }

        }

        private static void PLINQ2()
        {
            do
            {
                System.Console.WriteLine("start any key to start processing");
                Console.ReadLine();

                System.Console.WriteLine("processing");

                Task.Factory.StartNew(()=> ProcessIntData);
                System.Console.WriteLine("Enter Q to quit: ");

                string answer = Console.ReadLine();

                if(answer.Equals("Q", StringComparison.OrdinalIgnoreCase))
                {
                    cancelToken.Cancel();
                    break;
                }
            } while (true);
            Console.ReadLine();

        }

    }
}
