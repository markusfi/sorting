using System;

namespace SortingVisualisation
{
	/// <summary>
	/// Die Klasse Farbmetrib enthält alle farbmetrischen Berechnung, die in Winspek32 durchgeführt werden.
	/// </summary>
	public class Farbmetrik : FarbmetrikTabellen
	{
		/// <summary>
		/// Parameter zur Umrechnung des Messwerts von 0..100% auf den Windows RGB Wert von 1..255 zur Darstellung des Farbspektrums unter dem Transmissions- bzw. Absorbtionsdiagramm
		/// </summary>
		public static int	gSpektrumHelligkeit = 127;
		/// <summary>
		/// Parameter zur Verstärkung des Kontrasts bei der Darstellung des Farbspektrums unter dem Transmissions- bzw. Absorbtionsdiagramm
		/// </summary>
		public static int	gSpektrumKontrast = 0;

		/// <summary>
		/// Hilfsfunktion: Quadarat berechnen
		/// </summary>
		/// <param name="a"></param>
		/// <returns></returns>
		static double sqr(double a)
		{ 
			return a*a;
		}

		/// <summary>
		/// Hilfsfunktion: Wurzel der dritten Potenz berechnen über Logarithmus
		/// </summary>
		/// <param name="t"></param>
		/// <returns></returns>
		static double Wurzel3(double t)
		{
			if (t>0.0) 
			{
				return Math.Exp( (Math.Log(t) / 3.0));
			} 
			else 
			{
				return 0.0;
			}
		}

		/// <summary>
		/// Hilfsfunktion: dritte Potenz berechnen
		/// </summary>
		/// <param name="t"></param>
		/// <returns></returns>
		static double Potenz3(double t)
		{
			if (t > 0.0) 
			{           
				return Math.Exp(3.0 * Math.Log(t));
			} 
			else if (t < 0.0) 
			{
				return Math.Exp (3.0 * Math.Log(-t));	// Achtung: Hier ist offensichtlich ein FEHLER: sollte "return -Math.Exp(3.0*Math.Log(-t))" sein !!!
			} 
			else 
			{
				return 0.0;
			}
		}

		/// <summary>
		/// Umrechnung der Transmission bei gemessener Dicke in die gesuchte Dicke lt. dem Labert Beer´schen Gesetz.
		/// </summary>
		/// <param name="Spektrum">Spektrum Vektor, der umgerechnet wird</param>
		/// <param name="Quelldicke">Ausgangsdicke, Spektrum wurde für diese Dicke gemessen</param>
		/// <param name="Zieldicke">Zieldicke, d.h. berechnetes bei dieser Dicke </param>
		public static void LambertBeer(double []Spektrum, double Quelldicke, double Zieldicke)
		{   
			if (Zieldicke != Quelldicke && Quelldicke!=0.0) 
			{
				double dd=Zieldicke / Quelldicke;
				for (int i=0;i<Const.SpektrumVectorSize; i++) 
				{
					Spektrum[i] = ((Spektrum[i] >= 100.0) ? Spektrum[i] : ( (Spektrum[i] > 0.0) ? 100.0*Math.Exp( Math.Log(Spektrum[i]/100.0)*dd) : 0.0));
				}
			} 
		}	

		/// <summary>
		/// Umrechnung von XYZ nach CIE L*a*b* 
		/// </summary>
		/// <remarks>
		/// <para>Die Berechnung von CIE L*a*b* erfolgt nach der Formel aus:</para>
		/// <para>
		/// <B>Anni Gerger-Schunn, PRAKTISCHE Farbmessung, Seite 58</B>
		/// </para>
		/// </remarks>
		/// <param name="X">X Wert der Messung</param>
		/// <param name="Y">Y Wert der Messung</param>
		/// <param name="Z">Z Wert der Messung</param>
		/// <param name="Xn">Xn der Lichtart</param>
		/// <param name="Yn">Yn der Lichtart</param>
		/// <param name="Zn">Zn der Lichtart</param>
		/// <param name="L">Ergebnis CIE L*</param>
		/// <param name="a">Ergebnis CIE a*</param>
		/// <param name="b">Ergebnis CIE b*</param>
		public static void XYZToLAB(double X, double Y, double Z, double Xn, double Yn, double Zn, ref double L, ref double a, ref double b)
		{                                                                                   
			// Vergleiche: Anni Gerger-Schunn, PRAKTISCHE Farbmessung, Seite 58

			const double grenze=8.856001e-03;
			double Xq=X/Xn;
			double Xqa = Xq>grenze ? Wurzel3(Xq) : 7.787*Xq+(16.0/116.0);
			double Yq=Y/Yn;
			double Yqa = Yq>grenze ? Wurzel3(Yq) : 7.787*Yq+(16.0/116.0);
			double Zq=Z/Zn;
			double Zqa = Zq>grenze ? Wurzel3(Zq) : 7.787*Zq+(16.0/116.0);

			L = 116.0 * Yqa-16.0;				// könnte man kürzen, ist aber unnötig !
			a = 500.0 * (Xqa-Yqa);
			b = 200.0 * (Yqa-Zqa);
		}

		/// <summary>
		/// Umrechnung von XYZ nach xy nach der Formel <B>x = X /(X+Y+Z) </B> und <B>y = Y / (X+Y+Z)</B>
		/// </summary>
		/// <param name="X">X der Messung</param>
		/// <param name="Y">Y der Messung</param>
		/// <param name="Z">Z der Messung</param>
		/// <param name="_Y">entspricht dem Y</param>
		/// <param name="_x">x der Berechnung</param>
		/// <param name="_y">y der Berechnung</param>
		/// <returns>true wenn Berechnung durchgeführt werden konnte, false wenn X+Y+Z gleich 0</returns>
		public static bool XYZToYxy(double X, double Y, double Z, ref double _Y, ref double _x, ref double _y)
		{
			if (X+Y+Z != 0.0) 
			{
				_x = X / (X+Y+Z);	// Groß Y !!!
				_y = Y / (X+Y+Z);	// klein y !!!
				_Y = Y;
				return true;
			} 
			else 
			{   
				_Y=_x=_y=0.0;
				return false;
			}
		}

		/// <summary>
		/// Farbwinkel berechnen aus CIE L*a*b* der Messung
		/// </summary>
		/// <param name="L">CIE L* der Messung</param>
		/// <param name="a">CIE a* der Messung</param>
		/// <param name="b">CIE b* der Messung</param>
		/// <returns>Farbwinkel der CIE L*a*b* Werte</returns>
		public static double FarbWinkel(double L, double a, double b)
		{
			if (a != 0.0) 
			{
				double winkel = 180.0*Math.Atan(b/a)/Math.PI;
				if (a<0.0 && b>=0.0) 
				{
					return winkel + 180.0;
				} 
				else 
				{
					if (a<0.0 && b<0.0) 
					{
						return winkel + 180.0;
					} 
					else 
					{
						if (a>0.0 && b<0.0) 
						{
							return winkel + 360.0;
						} 
						else 
						{
							return winkel;
						}				
					}
				}
			} 
			else 
			{
				if (b==0.0) 
				{
					return 0.0;
				} 
				else if (b>=0.0) 
				{
					return 90.0;
				} 
				else 
				{
					return 270.0;
				}
			}
		}

		/// <summary>
		/// Chroma aus L*a*b* berechnen
		/// </summary>
		/// <param name="L">CIE L* der Messung</param>
		/// <param name="a">CIE a* der Messung</param>
		/// <param name="b">CIE b* der Messung</param>
		/// <returns>Berechnetes Chroma der Messung</returns>
		public static double Chroma(double L, double a, double b)
		{
			if (a!=0.0 || b!=0.0) 
			{
				return (Math.Sqrt(a*a+b*b));
			} 
			else 
			{
				return 0.0;
			}
		}

		/// <summary>
		/// Errechnet Delta E nach der Formel <B>Wurzel( (L0-L1)² + (A0-A1)² + (B0-B1)² )</B>
		/// </summary>
		/// <param name="L0">CIE L* Wert der Messung</param>
		/// <param name="A0">CIE a* Wert der Messung</param>
		/// <param name="B0">CIE b* Wert der Messung</param>
		/// <param name="L1">CIE L* Wert des Standards bzw. der Referenzmessung</param>
		/// <param name="A1">CIE a* Wert des Standards bzw. der Referenzmessung</param>
		/// <param name="B1">CIE b* Wert des Standards bzw. der Referenzmessung</param>
		/// <returns>Errechnetes Delta E</returns>
		public static double DeltaE(double L0, double A0, double B0,double L1, double A1, double B1)
		{
			if (L0 != 0.0 && A0 != 0.0 && B0 != 0.0) 
			{
				return Math.Sqrt( sqr(L0-L1) + sqr(A0-A1) + sqr(B0-B1));
			} 
			else 
			{
				return 0;
			}
		}

		/// <summary>
		/// Errechnet Delta AC nach der Formel <B>Wurzel( (a1-a2)² + (b1-b2)² )</B>
		/// </summary>
		/// <param name="a1">CIE a* Wert der Messung</param>
		/// <param name="b1">CIE b* Wert der Messung</param>
		/// <param name="a2">CIE a* Wert des Standards bzw. der Referenzmessung</param>
		/// <param name="b2">CIE b* Wert des Standards bzw. der Referenzmessung</param>
		/// <returns>Errechnetes Delta AC</returns>
		public static double DeletaAC(double a1, double b1, double a2, double b2)
		{
			if (a1 != 0.0 && b1 != 0.0) 
			{					// achtung L könnte auch null sein !!
				return Math.Sqrt( sqr(a1-a2) + sqr(b1-b2) );
			} 
			else 
			{
				return 0;
			}
		}

		/// <summary>
		///  Berechnet aus einem Spektraldatensatz von 1..76 Fließkommazahlen im Bereich
		///  0..100 % , angegeben als Integer im Bereich 0.10000, also direkt im Hunter-
		///  Format die Farbmasszahlen X,Y,Z wobei Lichtarten und
		///  Betrachtungswinkel angegeben werden müssen
		/// </summary>
		/// <param name="XX">Ergebnis Farbmasszahl X</param>
		/// <param name="YY">Ergebnis Farbmasszahl Y</param>
		/// <param name="ZZ">Ergebnis Farbmasszahl Z</param>
		/// <param name="Lichtart">Lichtart, bei der die Berechnung erfolgt</param>
		/// <param name="Winkel">Farbwinkel, bei dem die Berechnung erfolgt</param>
		/// <param name="InSpektrum">Spektrum, für das X Y Z berechnet werden soll</param>
		public static void FarbMassZahl(ref double XX, ref double YY, ref double ZZ, double []Lichtart, long Winkel, double []InSpektrum)
		{
			double []l_Spektrum = new double[Const.SpektrumVectorSize];        // Spektrum im Bereich 0..1
			double []xwinkel;
			double []ywinkel;
			double []zwinkel;			// Zeiger auf array 
			double kk;              	// Korrektrufaktor 
			for (int i=0;i<Const.SpektrumVectorSize;i++) 
			{		// Spektrum von Bereich 0%..100% transferieren in Bereich 0..1
				l_Spektrum[i]=InSpektrum[i]/100.0;
			}
			switch (Winkel) 
			{
			case 10:  
				xwinkel=X10;
				ywinkel=Y10;
				zwinkel=Z10;
				break;
			case 2:
				xwinkel=X2;
				ywinkel=Y2;
				zwinkel=Z2;
				break;
			default:                   
				System.Diagnostics.Debug.WriteLine("Falscher Betrachterwinkel !");
				xwinkel=X2;
				ywinkel=Y2;
				zwinkel=Z2;
				return;
			}
			XX=YY=ZZ=kk=0.0;			// alles auf 0 Setzen !

			for (int i=0;i<Const.SpektrumVectorSize;i++) 
			{
				kk += (Lichtart[i]*ywinkel[i]);
			}
			if (kk>0) 
				kk = 100.0/kk;
			else 
			{
				System.Diagnostics.Debug.WriteLine("Falscher Korrekturfaktor !");
			}

			for (int i=0;i<Const.SpektrumVectorSize;i++) 
			{
				XX += (kk*l_Spektrum[i]*Lichtart[i]*xwinkel[i]);
				YY += (kk*l_Spektrum[i]*Lichtart[i]*ywinkel[i]);		// rein weiß (Spektrum[lamda]=1) >> YY = 100 !
				ZZ += (kk*l_Spektrum[i]*Lichtart[i]*zwinkel[i]);
			}
		}

		/// <summary>
		/// Berechnet Delta E cmc der Messwerte CIE L*a*b* relativ zu der Referenzmessung L1 a1 b1 unter 
		/// Berücksichtigung der Parameter (l:c)
		/// </summary>
		/// <param name="L">CIE L* Wert der Messung</param>
		/// <param name="a">CIE a* Wert der Messung</param>
		/// <param name="b">CIE b* Wert der Messung</param>
		/// <param name="l">Parameter l</param>
		/// <param name="c">Parameter c</param>
		/// <param name="L1">CIE L* Wert des Standards bzw. der Referenzmessung</param>
		/// <param name="a1">CIE a* Wert des Standards bzw. der Referenzmessung</param>
		/// <param name="b1">CIE b* Wert des Standards bzw. der Referenzmessung</param>
		/// <returns>Errechnetes Delta E cmc</returns>
		public static double dECMC(double L, double a, double b, double l, double c, double L1, double a1, double b1)
		{
			if (c==0.0 || l==0.0) return 0.0; // div/0 vorbeugen !!!
			double C=Chroma(L,a,b);
			double H=FarbWinkel(L,a,b);
			double C1=Chroma(L1,a1,b1);
			double H1=FarbWinkel(L1,a1,b1);
			double dC=Math.Abs(C1-C);
			double dH=Math.Abs(H1-H);
			double dL=Math.Abs(L1-L);
			double SL=(L1<16 ? 0.511 : 0.040975*L1/(1+0.01765*L1));
			double SC=0.0683*C1/(1+0.0131*C1)+0.638;
			double T=(H1>=164 && H1<=345 ? 0.56 + Math.Abs(0.2*Math.Cos(Math.PI*(H1+168)/180)) : 0.36 + Math.Abs(0.4*Math.Cos(Math.PI*(H1+35)/180)));
			double C1q=C1*C1; C1q=C1q*C1q;
			double f=Math.Sqrt(C1q/(C1q+1900));                        
			double SH=SC*(T*f+1-f);
			if (SH==0.0 ||c*SC==0.0 || l*SL==0.0) return 0.0; 	 // div/0 vorbeugen !!!
			return (Math.Sqrt(sqr(dL/(l*SL))+sqr(dC/(c*SC))+sqr(dH/SH)));
		}


		/// <summary>
		/// Hilfsfunktion für Rahmen des Hemlholtzdiagramms
		/// </summary>
		/// <remarks>
		/// Berechnet für die Helmholtzdarstellung benötigte xy und XYZ Werte abhängig vom
		/// Betrachter und vom Offest, d.h. dem Index der Tabellen X2, Y2 und Z2 bzw. X10, Y10 und Z10
		/// </remarks>
		/// <param name="offset">Offset in den Tabllen</param>
		/// <param name="Betrachter">Betrachter (2 oder 10°)</param>
		/// <param name="x">Ergebnis x</param>
		/// <param name="y">Ergebnis y</param>
		/// <param name="X">Ergebnis X</param>
		/// <param name="Y">Ergebnis Y</param>
		/// <param name="Z">Ergebnis Z</param>
		/// <returns></returns>
		public static bool NormFarbTafel(int offset, long Betrachter, out double x, out double y, out double X, out double Y, out double Z)
		{
			double _Y=0;
			X=Y=Z=x=y=0;
			if (Betrachter==2 || Betrachter==10)
			{
				if (offset>=0 && offset<Const.SpektrumVectorSize) 
				{
					if (Betrachter==2) 
					{                
						X=X2[offset];
						Y=Y2[offset];
						Z=Z2[offset];        
					} 
					else 
					{
						X=X10[offset];
						Y=Y10[offset];
						Z=Z10[offset];        
					}		
					return XYZToYxy(X,Y,Z,ref _Y,ref x,ref y);   
				} 
				else 
				{
					return false;
				}
			} 
			else 
			{
				return false;
			}
		}

		/// <summary>
		/// die größte Amplitude für R
		/// </summary>
		static double maxAmplitudeR=0;		
		/// <summary>
		/// die größte Amplitude für G
		/// </summary>
		static double maxAmplitudeG=0;		
		/// <summary>
		/// die größte Amplitude für B
		/// </summary>
		static double maxAmplitudeB=0;		

		/// <summary>
		/// Ermittelt die maximale Amplitude von RGB für die Umrechnung von CIE L*a*b nach RGB
		/// </summary>
		public static void InitColorTable()
		{
			if (maxAmplitudeR==0 || maxAmplitudeG==0 || maxAmplitudeB==0) 
			{
				System.Diagnostics.Debug.WriteLine("\nInit Color Table");
				double R,G,B;
				double X,Y,Z;   
				for (int i=0;i<Const.SpektrumVectorSize;i++) 
				{
					X=X2[i];// * NormlichtC[Index];
					Y=Y2[i];// * NormlichtC[Index];
					Z=Z2[i];// * NormlichtC[Index];
					R =  0.4185*X - 0.1587*Y  - 0.0828*Z;
					G = -0.0912*X + 0.2524*Y  + 0.0157*Z;
					B =  0.0009*X - 0.0026*Y  + 0.1786*Z;
					maxAmplitudeR = Math.Max(maxAmplitudeR,R);
					maxAmplitudeG = Math.Max(maxAmplitudeG,G);
					maxAmplitudeB = Math.Max(maxAmplitudeB,B);
				}
				maxAmplitudeR = 1.0 / maxAmplitudeR;
				maxAmplitudeG = 1.0 / maxAmplitudeG;
				maxAmplitudeB = 1.0 / maxAmplitudeB;
			}
		}

		/// <summary>
		/// Ermittelt für eine Wellenlänge Lambda die RGB Werte zur Anzeige
		/// </summary>
		/// <param name="Lambda">Wellenlänge des Lichts</param>
		/// <returns>RGB Wert der Farbe des Lichts bei Wellenlänge Lambda</returns>
		public static System.Drawing.Color LambdaToRGB(int Lambda) // Wellenlänge in NanoMeter -> RGB
		{   
			int    Index = (Lambda - Const.SpektrumLambdaMin) / 5;
			if (Index >= 0 && Index < Const.SpektrumVectorSize) 
			{
				double R,G,B;
				double X,Y,Z;   
				if (Index<1) Index=1;		// der erste Wert stimmt nicht!

				InitColorTable();
				X=X2[Index];// * NormlichtC[Index];
				Y=Y2[Index];// * NormlichtC[Index];
				Z=Z2[Index];// * NormlichtC[Index];
				R =  0.4185*X - 0.1587*Y  - 0.0828*Z;
				G = -0.0912*X + 0.2524*Y  + 0.0157*Z;
				B =  0.0009*X - 0.0026*Y  + 0.1786*Z;

				if (Math.Max(R,0)+Math.Max(G,0)+Math.Max(B,0) > 0) 
				{
					if (gSpektrumHelligkeit > 0) 
					{
						if (gSpektrumKontrast > 1) 
						{
							double Kontrast=((double)(gSpektrumKontrast))/(10.0*Math.Max(R,Math.Max(G,B)));	// maximale Amplitude
							R *= Kontrast;
							G *= Kontrast;
							B *= Kontrast;
						} 
						else 
						{
							R *= maxAmplitudeR;
							G *= maxAmplitudeG;
							B *= maxAmplitudeB;
						}                                           
						double Helligkeit=255.0-gSpektrumHelligkeit;
						R = Math.Max(0,Math.Min(255,255.0 - Helligkeit + Helligkeit*R));
						G = Math.Max(0,Math.Min(255,255.0 - Helligkeit + Helligkeit*G));
						B = Math.Max(0,Math.Min(255,255.0 - Helligkeit + Helligkeit*B));
					} 
					else 
					{                    
						double Helligkeit= 155 * (R+G+B) * (maxAmplitudeR+maxAmplitudeG+maxAmplitudeB);
						R *= maxAmplitudeR;
						G *= maxAmplitudeG;
						B *= maxAmplitudeB;
						R = Math.Max(0,Math.Min(255,100+Helligkeit*R));
						G = Math.Max(0,Math.Min(255,100+Helligkeit*G));
						B = Math.Max(0,Math.Min(255,100+Helligkeit*B));
					}
					return System.Drawing.Color.FromArgb((int)R,(int)G,(int)B);
				} 
			} 
			return System.Drawing.Color.FromArgb(0,0,0);
		}

		/// <summary>
		/// Errechnet aus X, Y, Z den korrespondierende RGB Wert zur Anzeige
		/// Berücksichtigt maxmiale Amplitude 
		/// </summary>
		/// <remarks><p>Die Berechnung erfolgt nach der Formel:</p>
		/// <p>R =  0.4185*X - 0.1587*Y  - 0.0828*Z</p>
		/// <p>G = -0.0912*X + 0.2524*Y  + 0.0157*Z</p>
		/// <p>B =  0.0009*X - 0.0026*Y  + 0.1786*Z</p>
		/// </remarks>
		/// <param name="X">X der Messung</param>
		/// <param name="Y">Y der Messung</param>
		/// <param name="Z">Z der Messung</param>
		/// <returns>RGB Wert zur Anzeige</returns>
		public static System.Drawing.Color XYZToRGB(double X, double Y, double Z) // XYZ -> RGB
		{   
			double R,G,B;
			InitColorTable();

			R =  0.4185*X - 0.1587*Y  - 0.0828*Z;
			G = -0.0912*X + 0.2524*Y  + 0.0157*Z;
			B =  0.0009*X - 0.0026*Y  + 0.1786*Z;

			if (Math.Max(R,0)+Math.Max(G,0)+Math.Max(B,0) > 0) 
			{
				if (gSpektrumHelligkeit > 0) 
				{
					if (gSpektrumKontrast > 1) 
					{
						double Kontrast=((double)(gSpektrumKontrast))/(10.0*Math.Max(R,Math.Max(G,B)));	// maximale Amplitude
						R *= Kontrast;
						G *= Kontrast;
						B *= Kontrast;
					} 
					else 
					{
						R *= maxAmplitudeR;
						G *= maxAmplitudeG;
						B *= maxAmplitudeB;
					}                                           
					double Helligkeit=255.0-gSpektrumHelligkeit;
					R = Math.Max(0,Math.Min(255,255.0 - Helligkeit + Helligkeit*R));
					G = Math.Max(0,Math.Min(255,255.0 - Helligkeit + Helligkeit*G));
					B = Math.Max(0,Math.Min(255,255.0 - Helligkeit + Helligkeit*B));
				} 
				else 
				{                    
					double Helligkeit= 155 * (R+G+B) * (maxAmplitudeR+maxAmplitudeG+maxAmplitudeB);
					R *= maxAmplitudeR;
					G *= maxAmplitudeG;
					B *= maxAmplitudeB;
					R = Math.Max(0,Math.Min(255,100+Helligkeit*R));
					G = Math.Max(0,Math.Min(255,100+Helligkeit*G));
					B = Math.Max(0,Math.Min(255,100+Helligkeit*B));
				}
				return System.Drawing.Color.FromArgb((int)R,(int)G,(int)B);
			} 
			return System.Drawing.Color.FromArgb(0,0,0);
		}

		/// <summary>
		/// Alternative Methode um aus X, Y, Z den korrespondierende RGB Wert zur Anzeige zu berechnen.
		/// Berücksichtigt Gamma Faktor
		/// </summary>
		/// <remarks><p>Die Berechnung erfolgt nach der Formel:</p>
		/// <p>R =  3.05958989*X  - 1.39274638*Y  - 0.474677324*Z</p>
		/// <p>G = -0.96762873*X  + 1.874840829*Y + 0.04166583*Z</p>
		/// <p>B =  0.068796524*X - 0.229898168*Y + 1.069304567*Z</p>
		/// </remarks>
		/// <param name="X">X der Messung</param>
		/// <param name="Y">Y der Messung</param>
		/// <param name="Z">Z der Messung</param>
		/// <returns>RGB Wert zur Anzeige</returns>
		public static System.Drawing.Color XYZToRGB2(double X, double Y, double Z) // XYZ -> RGB
		{
			double R, G, B;
			InitColorTable ();     

			R = 3.05958989 * X - 1.39274638 * Y - 0.474677324 * Z;
			G = -0.96762873 * X + 1.874840829 * Y + 0.04166583 * Z;
			B = 0.068796524 * X - 0.229898168 * Y + 1.069304567 * Z;

			/*	R = 2.042*X - 0.565*Y - 0.345*Z;
			G = -0.894*X + 1.815*Y + 0.032*Z; 
			B = 0.064*X - 0.129*Y + 0.912*Z;

			R = 3.240479*X - 1.537150*Y - 0.498535*Z;
			G = -0.969256*X + 1.875992*Y + 0.041556*Z; 
			B = 0.055648*X - 0.204043*Y + 1.057311*Z;
              
			R = 3.5058*X - 1.7397*Y - 0.5440*Z;
			G =-1.0690*X + 1.9778*Y + 0.0352*Z;  
			B = 0.0563*X - 0.1970*Y + 1.0501*Z;

			R = 1.910*X - 0.532*Y - 0.288*Z;
			G =-0.985*X + 1.999*Y - 0.028*Z;   
			B = 0.058*X - 0.118*Y + 0.898*Z;

			R =  0.4185*X - 0.1587*Y  - 0.0828*Z;
			G = -0.0912*X + 0.2524*Y  + 0.0157*Z;
			B =  0.0009*X - 0.0026*Y  + 0.1786*Z;
		*/
			R = R < 0.0 ? 0 : R;
			G = G < 0.0 ? 0 : G;
			B = B < 0.0 ? 0 : B;       

			double gamma, a, b;
			gamma = 1.0 / 2.35; 
			a = 200.0; 
			b = 35.0;
			R = a * Math.Exp (gamma * Math.Log (R / 100.0)) + b;	
			G = a * Math.Exp (gamma * Math.Log (G / 100.0)) + b;
			B = a * Math.Exp (gamma * Math.Log (B / 100.0)) + b;        
			return System.Drawing.Color.FromArgb ((int)Math.Min (255, R), (int)Math.Min (255, G), (int)Math.Min (255, B));
		}
	}
}

