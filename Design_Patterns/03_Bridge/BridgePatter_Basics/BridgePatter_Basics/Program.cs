using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePatter_Basics
{
    3 class BridgePattern {
4
5 // Bridge Pattern Judith Bishop Dec 2006, Aug 2007
6 // Shows an abstraction and two implementations proceeding independently
7
Client <<interface>>
Bridge
+OperationImp( )
Abstraction
–bridge
+Operation( )
Calls OperationImp
in bridge

8 class Abstraction {
9 Bridge bridge;
10 public Abstraction (Bridge implementation) {
11 bridge = implementation;
12 }
13 public string Operation ( ) {
14 return "Abstraction" +" <<< BRIDGE >>>> "+bridge.OperationImp( );
15 }
16 }
17
18 interface Bridge {
19 string OperationImp( );
20 }
21
22 class ImplementationA : Bridge {
23 public string OperationImp ( ) {
24 return "ImplementationA";
25 }
26 }
27
28 class ImplementationB : Bridge {
29 public string OperationImp ( ) {
30 return "ImplementationB";
31 }
32 }
33
34 static void Main ( ) {
35 Console.WriteLine("Bridge Pattern\n");
36 Console.WriteLine(new Abstraction (new ImplementationA( )).Operation( ));
37 Console.WriteLine(new Abstraction (new ImplementationB( )).Operation( ));
38 }
39 }
}
