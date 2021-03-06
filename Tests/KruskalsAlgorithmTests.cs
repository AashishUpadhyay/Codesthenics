﻿using System;
using Problems;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class KruskalsAlgorithmTests
    {
        [TestMethod]
        public void Test1()
        {
            var ka = new KruskalsAlgorithm();
            int[][] edges = new int[3][]
            {
                new int[]{1,2,5},
                new int[]{1,3,6},
                new int[]{2,3,1}
            };
            int received = ka.MinimumSpanningTreeCost(3, edges);
            int expected = 6;
            Assert.AreEqual(received, expected);
        }

        [TestMethod]
        public void Test2()
        {
            var ka = new KruskalsAlgorithm();
            int[][] edges = new int[2][]
            {
                new int[]{1,2,3},
                new int[]{3,4,4},
            };
            int received = ka.MinimumSpanningTreeCost(4, edges);
            int expected = -1;
            Assert.AreEqual(received, expected);
        }

        [TestMethod]
        public void Test3()
        {
            var ka = new KruskalsAlgorithm();
            int[][] edges = new int[3][]
            {
                new int[]{1,2,2},
                new int[]{2,3,3},
                new int[]{ 2, 4, 2 }
            };
            int received = ka.MinimumSpanningTreeCost(4, edges);
            int expected = 7;
            Assert.AreEqual(received, expected);
        }

        [TestMethod]
        public void Test4()
        {
            var ka = new KruskalsAlgorithm();
            int[][] edges = new int[4][]
            {
                new int[]{2,1,50459},
                new int[]{3,2,47477},
                new int[]{ 4, 2, 52585 },
                new int[]{ 5,3,16477 }
            };
            int received = ka.MinimumSpanningTreeCost(5, edges);
            int expected = 166998;
            Assert.AreEqual(received, expected);
        }

        [TestMethod]
        public void Test5()
        {
            var ka = new KruskalsAlgorithm();
            int[][] edges = new int[489][]
            {
                new int[]{ 2,1,96265},
                new int[]{3,1,13546},
                new int[]{ 4,2,65556},
                new  int[]{ 5,1,94455},
                new  int[]{ 6,4,16956},
                new  int[]{ 7,4,54923},
                new  int[]{ 8,3,12808},
                new  int[]{ 9,2,32981},
                new  int[]{ 10,2,88469},
                new  int[]{ 11,3,26103},
                new  int[]{ 12,7,96167},
                new  int[]{ 13,7,32622},
                new  int[]{ 14,7,84049},
                new  int[]{ 15,9,78522},
                new  int[]{ 16,5,94422},
                new  int[]{ 17,3,16657},
                new  int[]{ 18,3,51507},
                new  int[]{ 19,5,32760},
                new  int[]{ 20,17,62989},
                new  int[]{ 21,19,5140},
                new  int[]{ 22,5,39916},
                new  int[]{ 23,12,28762},
                new  int[]{ 24,8,93993},
                new  int[]{ 25,21,61085},
                new  int[]{ 26,9,18604},
                new  int[]{ 27,4,11240},
                new  int[]{ 28,27,41413},
                new  int[]{ 29,14,55189},
                new  int[]{ 30,25,91867},
                new  int[]{ 31,6,27505},
                new  int[]{ 32,15,2843},
                new  int[]{ 33,19,3235},
                new  int[]{ 34,7,82792},
                new  int[]{ 35,15,94548},
                new  int[]{ 36,20,1134},
                new  int[]{ 37,32,86612},
                new  int[]{ 38,15,9710},
                new  int[]{ 39,9,3045},
                new  int[]{ 40,28,84072},
                new  int[]{ 41,19,18528},
                new  int[]{ 42,35,71842},
                new  int[]{ 43,33,41797},
                new  int[]{ 44,15,76332},
                new  int[]{ 45,20,70775},
                new  int[]{ 46,36,8866},
                new  int[]{ 47,24,53070},
                new  int[]{ 48,25,70590},
                new  int[]{ 49,13,60336},
                new  int[]{ 50,38,81240},
                new  int[]{ 51,41,42873},
                new  int[]{ 52,47,21248},
                new  int[]{ 53,19,63013},
                new  int[]{ 54,31,89740},
                new  int[]{ 55,18,23361},
                new  int[]{ 56,46,43892},
                new  int[]{ 57,26,73433},
                new  int[]{ 58,38,42919},
                new  int[]{ 59,38,56229},
                new  int[]{ 60,37,72954},
                new  int[]{ 61,28,83617},
                new  int[]{ 62,38,25762},
                new  int[]{ 63,40,32935},
                new  int[]{ 64,41,89162},
                new  int[]{ 65,50,93899},
                new  int[]{ 66,34,77805},
                new  int[]{ 67,42,72385},
                new  int[]{ 68,3,90741},
                new  int[]{ 69,8,53562},
                new  int[]{ 70,8,84751},
                new  int[]{ 71,29,54674},
                new  int[]{ 72,5,33225},
                new  int[]{ 73,44,94969},
                new  int[]{ 74,41,17996},
                new  int[]{ 75,30,21264},
                new  int[]{ 76,49,91253},
                new  int[]{ 77,11,24677},
                new  int[]{ 78,28,18316},
                new  int[]{ 79,24,85478},
                new  int[]{ 80,61,75416},
                new  int[]{ 81,33,23551},
                new  int[]{ 82,11,11550},
                new  int[]{ 83,67,16113},
                new  int[]{ 84,12,1697},
                new  int[]{ 85,40,6177},
                new  int[]{ 86,36,25407},
                new  int[]{ 87,22,80693},
                new  int[]{ 88,53,92993},
                new  int[]{ 89,48,92479},
                new  int[]{ 90,38,70562},
                new  int[]{ 91,48,38853},
                new  int[]{ 92,56,98521},
                new  int[]{ 93,43,16063},
                new  int[]{ 94,56,16070},
                new  int[]{ 95,77,55767},
                new  int[]{ 96,3,88718},
                new  int[]{ 97,26,39082},
                new  int[]{ 98,74,23666},
                new  int[]{ 99,52,56144},
                new  int[]{ 100,83,32428},
                new  int[]{ 101,61,90071},
                new  int[]{ 102,51,606},
                new  int[]{ 103,12,77133},
                new  int[]{ 104,33,50238},
                new  int[]{ 105,14,5301},
                new  int[]{ 106,104,29269},
                new  int[]{ 107,76,36471},
                new  int[]{ 108,94,35303},
                new  int[]{ 109,30,42003},
                new  int[]{ 110,52,89791},
                new  int[]{ 111,11,35732},
                new  int[]{ 112,67,78089},
                new  int[]{ 113,29,26161},
                new  int[]{ 114,6,79388},
                new  int[]{ 115,5,33277},
                new  int[]{ 116,32,39987},
                new  int[]{ 117,109,56552},
                new  int[]{ 118,88,82784},
                new  int[]{ 119,31,53891},
                new  int[]{ 120,45,8419},
                new  int[]{ 121,111,61897},
                new  int[]{ 122,2,56946},
                new  int[]{ 123,58,69071},
                new  int[]{ 124,98,2971},
                new  int[]{ 125,99,5198},
                new  int[]{ 126,6,90354},
                new  int[]{ 127,10,6962},
                new  int[]{ 128,18,97019},
                new  int[]{ 129,107,3916},
                new  int[]{ 130,88,32770},
                new  int[]{ 131,128,93318},
                new  int[]{ 132,56,62466},
                new  int[]{ 133,40,23011},
                new  int[]{ 134,125,54176},
                new  int[]{ 135,47,23358},
                new  int[]{ 136,52,80051},
                new  int[]{ 137,106,63674},
                new  int[]{ 138,98,27038},
                new  int[]{ 139,21,84820},
                new  int[]{ 140,43,58348},
                new  int[]{ 141,7,55109},
                new  int[]{ 142,44,46866},
                new  int[]{ 143,83,47085},
                new  int[]{ 144,93,90748},
                new  int[]{ 145,67,63885},
                new  int[]{ 146,48,48283},
                new  int[]{ 147,120,84965},
                new  int[]{ 148,129,36135},
                new  int[]{ 149,108,44949},
                new  int[]{ 150,92,84320},
                new  int[]{ 151,118,96184},
                new  int[]{ 152,64,17188},
                new  int[]{ 153,143,79081},
                new  int[]{ 154,110,86340},
                new  int[]{ 155,118,15875},
                new  int[]{ 156,43,80318},
                new  int[]{ 157,44,24856},
                new  int[]{ 158,44,19276},
                new  int[]{ 159,149,18973},
                new  int[]{ 160,63,70944},
                new  int[]{ 161,69,73116},
                new  int[]{ 162,11,24943},
                new  int[]{ 163,78,9541},
                new  int[]{ 164,66,64783},
                new  int[]{ 165,59,99684},
                new  int[]{ 166,49,90668},
                new  int[]{ 167,164,17231},
                new  int[]{ 168,60,16894},
                new  int[]{ 169,134,38595},
                new  int[]{ 170,13,77181},
                new  int[]{ 171,169,25727},
                new  int[]{ 172,13,12929},
                new  int[]{ 173,84,18763},
                new  int[]{ 174,33,96164},
                new  int[]{ 175,110,74298},
                new  int[]{ 176,79,7884},
                new  int[]{ 177,162,28920},
                new  int[]{ 178,31,4738},
                new  int[]{ 179,112,51236},
                new  int[]{ 180,54,34515},
                new  int[]{ 181,116,77226},
                new  int[]{ 182,1,81128},
                new  int[]{ 183,115,45558},
                new  int[]{ 184,105,89741},
                new  int[]{ 185,112,4204},
                new  int[]{ 186,142,51796},
                new  int[]{ 187,28,56776},
                new  int[]{ 188,92,37397},
                new  int[]{ 189,170,79659},
                new  int[]{ 190,27,96428},
                new  int[]{ 191,104,4597},
                new  int[]{ 192,81,11127},
                new  int[]{ 193,72,39904},
                new  int[]{ 194,174,66360},
                new  int[]{ 195,123,20831},
                new  int[]{ 196,50,37291},
                new  int[]{ 197,131,64313},
                new  int[]{ 198,56,93770},
                new  int[]{ 199,2,70917},
                new  int[]{ 200,22,67612},
                new  int[]{ 201,12,97292},
                new  int[]{ 202,8,91628},
                new  int[]{ 203,28,31209},
                new  int[]{ 204,89,7192},
                new  int[]{ 205,75,32616},
                new  int[]{ 206,181,80204},
                new  int[]{ 207,166,36832},
                new  int[]{ 208,73,97070},
                new  int[]{ 209,9,8559},
                new  int[]{ 210,134,4929},
                new  int[]{ 211,151,35521},
                new  int[]{ 212,162,41924},
                new  int[]{ 213,125,40737},
                new  int[]{ 214,33,41090},
                new  int[]{ 215,69,42710},
                new  int[]{ 216,6,26951},
                new  int[]{ 217,170,99970},
                new  int[]{ 218,103,75885},
                new  int[]{ 219,94,61059},
                new  int[]{ 220,212,76807},
                new  int[]{ 221,37,92895},
                new  int[]{ 222,185,7304},
                new  int[]{ 223,219,33420},
                new  int[]{ 224,212,42385},
                new  int[]{ 225,84,85011},
                new  int[]{ 226,38,46753},
                new  int[]{ 227,90,59204},
                new  int[]{ 228,90,4386},
                new  int[]{ 229,212,63043},
                new  int[]{ 230,126,33941},
                new  int[]{ 231,211,89371},
                new  int[]{ 232,103,60997},
                new  int[]{ 233,66,45395},
                new  int[]{ 234,110,89623},
                new  int[]{ 235,64,54527},
                new  int[]{ 236,182,98708},
                new  int[]{ 237,86,4783},
                new  int[]{ 238,156,65023},
                new  int[]{ 239,43,9296},
                new  int[]{ 240,126,87102},
                new  int[]{ 241,218,41047},
                new  int[]{ 242,21,69075},
                new  int[]{ 243,90,4358},
                new  int[]{ 244,111,23023},
                new  int[]{ 245,138,47184},
                new  int[]{ 246,167,58195},
                new  int[]{ 247,5,6029},
                new  int[]{ 248,32,11031},
                new  int[]{ 249,228,48948},
                new  int[]{ 250,248,49607},
                new  int[]{ 251,100,7135},
                new  int[]{ 252,249,54991},
                new  int[]{ 253,157,24418},
                new  int[]{ 254,126,50098},
                new  int[]{ 255,222,74659},
                new  int[]{ 256,185,49962},
                new  int[]{ 257,74,51656},
                new  int[]{ 258,222,97088},
                new  int[]{ 259,13,98971},
                new  int[]{ 260,158,83320},
                new  int[]{ 261,87,4305},
                new  int[]{ 262,168,4116},
                new  int[]{ 263,157,20361},
                new  int[]{ 264,194,68523},
                new  int[]{ 265,137,68695},
                new  int[]{ 266,243,12174},
                new  int[]{ 267,81,45584},
                new  int[]{ 268,114,92420},
                new  int[]{ 269,127,99817},
                new  int[]{ 270,57,64114},
                new  int[]{ 271,46,28497},
                new  int[]{ 272,52,26051},
                new  int[]{ 273,260,14307},
                new  int[]{ 274,214,25472},
                new  int[]{ 275,109,53494},
                new  int[]{ 276,222,37689},
                new  int[]{ 277,265,66085},
                new  int[]{ 278,232,81111},
                new  int[]{ 279,239,86194},
                new  int[]{ 280,223,68740},
                new  int[]{ 281,136,17670},
                new  int[]{ 282,183,1873},
                new  int[]{ 283,63,19173},
                new  int[]{ 284,38,48616},
                new  int[]{ 285,102,42522},
                new  int[]{ 286,173,25860},
                new  int[]{ 287,31,17129},
                new  int[]{ 288,85,40235},
                new  int[]{ 289,264,9031},
                new  int[]{ 290,166,75165},
                new  int[]{ 291,197,52348},
                new  int[]{ 292,69,4433},
                new  int[]{ 293,6,90783},
                new  int[]{ 294,152,68050},
                new  int[]{ 295,48,18510},
                new  int[]{ 296,58,90002},
                new  int[]{ 297,106,8056},
                new  int[]{ 298,164,59519},
                new  int[]{ 299,280,59996},
                new  int[]{ 300,73,70272},
                new  int[]{ 301,64,15694},
                new  int[]{ 302,192,71573},
                new  int[]{ 303,237,49195},
                new  int[]{ 304,144,72024},
                new  int[]{ 305,166,83286},
                new  int[]{ 306,91,33900},
                new  int[]{ 307,79,87974},
                new  int[]{ 308,209,42077},
                new  int[]{ 309,53,18320},
                new  int[]{ 310,76,96171},
                new  int[]{ 311,130,17352},
                new  int[]{ 312,210,97890},
                new  int[]{ 313,13,17548},
                new  int[]{ 314,124,68492},
                new  int[]{ 315,164,33684},
                new  int[]{ 316,11,56175},
                new  int[]{ 317,32,14320},
                new  int[]{ 318,264,94531},
                new  int[]{ 319,129,14100},
                new  int[]{ 320,13,10742},
                new  int[]{ 321,175,5488},
                new  int[]{ 322,160,72294},
                new  int[]{ 323,175,6528},
                new  int[]{ 324,166,69798},
                new  int[]{ 325,134,25356},
                new  int[]{ 326,308,36977},
                new  int[]{ 327,51,5711},
                new  int[]{ 328,24,78384},
                new  int[]{ 329,323,92898},
                new  int[]{ 330,69,86456},
                new  int[]{ 331,173,99320},
                new  int[]{ 332,264,5215},
                new  int[]{ 333,91,9500},
                new  int[]{ 334,43,18117},
                new  int[]{ 335,69,74957},
                new  int[]{ 336,329,29965},
                new  int[]{ 337,306,53268},
                new  int[]{ 338,238,87222},
                new  int[]{ 339,238,15202},
                new  int[]{ 340,281,76774},
                new  int[]{ 341,150,4433},
                new  int[]{ 342,30,14930},
                new  int[]{ 343,87,17913},
                new  int[]{ 344,100,43511},
                new  int[]{ 345,131,49183},
                new  int[]{ 346,289,50196},
                new  int[]{ 347,221,11759},
                new  int[]{ 348,102,37402},
                new  int[]{ 349,323,75014},
                new  int[]{ 350,348,49091},
                new  int[]{ 351,145,84685},
                new  int[]{ 352,238,39800},
                new  int[]{ 353,95,99400},
                new  int[]{ 354,270,79771},
                new  int[]{ 355,181,65488},
                new  int[]{ 356,152,32489},
                new  int[]{ 357,275,13552},
                new  int[]{ 358,44,46881},
                new  int[]{ 359,220,35171},
                new  int[]{ 360,86,15511},
                new  int[]{ 361,173,80866},
                new  int[]{ 362,203,55758},
                new  int[]{ 363,317,54868},
                new  int[]{ 364,269,44700},
                new  int[]{ 365,294,17936},
                new  int[]{ 366,346,4837},
                new  int[]{ 367,208,24805},
                new  int[]{ 368,250,20637},
                new  int[]{ 369,38,64546},
                new  int[]{ 370,241,20734},
                new  int[]{ 371,358,33322},
                new  int[]{ 372,73,54904},
                new  int[]{ 373,35,1288},
                new  int[]{ 374,309,46255},
                new  int[]{ 375,264,38509},
                new  int[]{ 376,161,92287},
                new  int[]{ 377,98,36932},
                new  int[]{ 378,105,95637},
                new  int[]{ 379,334,73084},
                new  int[]{ 380,5,71362},
                new  int[]{ 381,303,59290},
                new  int[]{ 382,100,82433},
                new  int[]{ 383,295,72642},
                new  int[]{ 384,360,59145},
                new  int[]{ 385,312,68772},
                new  int[]{ 386,143,79542},
                new  int[]{ 387,292,59600},
                new  int[]{ 388,332,1856},
                new  int[]{ 389,46,83494},
                new  int[]{ 390,236,70992},
                new  int[]{ 391,124,11911},
                new  int[]{ 392,72,99227},
                new  int[]{ 393,353,70076},
                new  int[]{ 394,30,74481},
                new  int[]{ 395,14,72296},
                new  int[]{ 396,85,92552},
                new  int[]{ 397,111,86171},
                new  int[]{ 398,324,37426},
                new  int[]{ 399,140,15924},
                new  int[]{ 400,247,71343},
                new  int[]{ 401,116,43050},
                new  int[]{ 402,261,70803},
                new  int[]{ 403,141,97362},
                new  int[]{ 404,271,68971},
                new  int[]{ 405,322,36005},
                new  int[]{ 406,289,30064},
                new  int[]{ 407,196,8971},
                new  int[]{ 408,137,49204},
                new  int[]{ 409,146,81499},
                new  int[]{ 410,321,72922},
                new  int[]{ 411,383,54247},
                new  int[]{ 412,35,1580},
                new  int[]{ 413,216,51354},
                new  int[]{ 414,131,91030},
                new  int[]{ 415,407,49837},
                new  int[]{ 416,330,54995},
                new  int[]{ 417,250,34918},
                new  int[]{ 418,288,48373},
                new  int[]{ 419,205,63531},
                new  int[]{ 420,293,3124},
                new  int[]{ 421,345,95525},
                new  int[]{ 422,106,29135},
                new  int[]{ 423,7,74939},
                new  int[]{ 424,394,37149},
                new  int[]{ 425,325,13892},
                new  int[]{ 426,52,79557},
                new  int[]{ 427,302,3685},
                new  int[]{ 428,336,16312},
                new  int[]{ 429,380,28206},
                new  int[]{ 430,130,49036},
                new  int[]{ 431,411,32317},
                new  int[]{ 432,216,93183},
                new  int[]{ 433,251,17697},
                new  int[]{ 434,385,84204},
                new  int[]{ 435,360,83214},
                new  int[]{ 436,257,48831},
                new  int[]{ 437,282,25590},
                new  int[]{ 438,214,76746},
                new  int[]{ 439,150,86244},
                new  int[]{ 440,257,71304},
                new  int[]{ 441,83,12573},
                new  int[]{ 442,312,9028},
                new  int[]{ 443,204,90905},
                new  int[]{ 444,181,28827},
                new  int[]{ 445,302,86266},
                new  int[]{ 446,345,9231},
                new  int[]{ 447,225,96833},
                new  int[]{ 448,89,10073},
                new  int[]{ 449,357,11942},
                new  int[]{ 450,319,97370},
                new  int[]{ 451,152,41158},
                new  int[]{ 452,112,15291},
                new  int[]{ 453,117,33249},
                new  int[]{ 454,429,84168},
                new  int[]{ 455,393,69605},
                new  int[]{ 456,128,29164},
                new  int[]{ 457,315,28540},
                new  int[]{ 458,23,20175},
                new  int[]{ 459,39,31170},
                new  int[]{ 460,283,62302},
                new  int[]{ 461,371,45332},
                new  int[]{ 462,268,74923},
                new  int[]{ 463,191,75385},
                new  int[]{ 464,179,76894},
                new  int[]{ 465,250,27506},
                new  int[]{ 466,24,54980},
                new  int[]{ 467,331,85918},
                new  int[]{ 468,152,53073},
                new  int[]{ 469,175,62262},
                new  int[]{ 470,46,77042},
                new  int[]{ 471,238,85344},
                new  int[]{ 472,81,94186},
                new  int[]{ 473,101,12508},
                new  int[]{ 474,316,58785},
                new  int[]{ 475,403,63186},
                new  int[]{ 476,258,88874},
                new  int[]{ 477,225,67887},
                new  int[]{ 478,189,37726},
                new  int[]{ 479,39,38965},
                new  int[]{ 480,212,86541},
                new  int[]{ 481,313,3450},
                new  int[]{ 482,288,8718},
                new  int[]{ 483,162,57242},
                new  int[]{ 484,391,74804},
                new  int[]{ 485,166,61300},
                new  int[]{ 486,216,70549},
                new  int[]{ 487,421,197},
                new  int[]{ 488,285,55523},
                new  int[]{ 489,409,34306},
                new  int[]{ 490,468,59400}
            };
            int received = ka.MinimumSpanningTreeCost(490, edges);
            int expected = 24583095;
            Assert.AreEqual(received, expected);
        }
    }
}
