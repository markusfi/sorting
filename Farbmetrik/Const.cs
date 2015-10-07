using System;

namespace SortingVisualisation
{
	/// <summary>
	/// Konstanten in winspek32
	/// </summary>
	public class Const
	{
		/// <summary>
		/// Anzahl der Wellenl鋘gen des Spektrums
		/// </summary>
		public const int SpektrumVectorSize = 76;
		/// <summary>
		/// Minimale Wellenl鋘ge des Spektrums
		/// </summary>
		public const int SpektrumLambdaMin = 375;
		/// <summary>
		/// Maximale Wellenl鋘ge des Spektrums
		/// </summary>
		public const int SpektrumLambdaMax = 750;
		/// <summary>
		/// Abstand der Wellenl鋘gen
		/// </summary>
		public const int SpektrumLambdaDelta = 5;	

		/// <summary>
		/// Index des Image f黵 Bezugstandard
		/// </summary>
		public const int imageIndexBezugStandard = 36;
		/// <summary>
		/// Index des Image f黵 Standard
		/// </summary>
		public const int imageIndexStandard = 35;

		public const int imageIndexKommission = 52;
		/// <summary>
		/// Anzahl der Zoomstufen
		/// </summary>
		public const int ZoomStufen = 10;

		/// <summary>
		/// Anzahl der Farben, die f黵 die Darstellung definiert werden k鰊nen
		/// </summary>
		public const int AnzahlFarben = 256;

		/// <summary>
		/// Text ID des Parameters <B>paramDeltaE</B>, mit <I>DeltaE</I> als Schl黶sel in der Tabelle Parameter
		/// </summary>
		public const string paramDeltaE = "DeltaE";
		/// <summary>
		/// Text ID des Parameters 'paramKontrast', mit "Kontrast" als Schl黶sel in der Tabelle Parameter
		/// </summary>
		public const string paramKontrast = "Kontrast";
		/// <summary>
		/// Text ID des Parameters <B>paramHelligkeit</B>, mit <I>Helligkeit</I> als Schl黶sel in der Tabelle Parameter
		/// </summary>
		public const string paramHelligkeit = "Helligkeit";
		/// <summary>
		/// Text ID des Parameters <B>paramMessfarbenVerwenden</B>, mit <I>MessfarbenVerwenden</I> als Schl黶sel in der Tabelle Parameter
		/// </summary>
		public const string paramMessfarbenVerwenden = "MessfarbenVerwenden";
		/// <summary>
		/// Text ID des Parameters <B>paramWarnungUmrechnungsfaktor</B>, mit <I>WarnungUmrechnungsfaktor</I> als Schl黶sel in der Tabelle Parameter
		/// </summary>
		public const string paramWarnungUmrechnungsfaktor = "WarnungUmrechnungsfaktor";
		/// <summary>
		/// Text ID des Parameters <B>paramEDiagramlMin</B>, mit <I>EDiagramlMin</I> als Schl黶sel in der Tabelle Parameter
		/// </summary>
		public const string paramEDiagramlMin = "EDiagramlMin";
		/// <summary>
		/// Text ID des Parameters <B>paramEDiagramlMax</B>, mit <I>EDiagramlMax</I> als Schl黶sel in der Tabelle Parameter
		/// </summary>
		public const string paramEDiagramlMax = "EDiagramlMax";
		/// <summary>
		/// Text ID des Parameters <B>paramEDiagramabMin</B>, mit <I>EDiagramabMin</I> als Schl黶sel in der Tabelle Parameter
		/// </summary>
		public const string paramEDiagramabMin = "EDiagramabMin";
		/// <summary>
		/// Text ID des Parameters <B>paramEDiagramabMax</B>, mit <I>EDiagramabMax</I> als Schl黶sel in der Tabelle Parameter
		/// </summary>
		public const string paramEDiagramabMax = "EDiagramabMax";
		/// <summary>
		/// Text ID des Parameters <B>paramFarbe</B>, mit <I>Farbe</I> als Schl黶sel in der Tabelle Parameter
		/// </summary>
		public const string paramFarbe = "Farbe";
		/// <summary>
		/// Text ID des Parameters <B>paramSpektrumAnzeigen</B>, mit <I>SpektrumAnzeigen</I> als Schl黶sel in der Tabelle Parameter
		/// </summary>
		public const string paramSpektrumAnzeigen = "SpektrumAnzeigen";
		/// <summary>
		/// Text ID des Parameters <B>paramImportArtikelPath</B>, mit <I>ImportArtikelPath</I> als Schl黶sel in der Tabelle Parameter
		/// </summary>
		public const string paramImportArtikelPath = "ImportArtikelPath";
		/// <summary>
		/// Text ID des Parameters <B>paramImportWinspekDBFPath</B>, mit <I>ImportWinspekDBFPath</I> als Schl黶sel in der Tabelle Parameter
		/// </summary>
		public const string paramImportWinspekDBFPath = "ImportWinspekDBFPath";
		/// <summary>
		/// Kommaseparierte Schnittstellenbeschreibung: PC,Port,Baud,Delay,XE
		/// </summary>
		public const string paramSchnittstelle = "Schnittstelle";
		/// <summary>
		/// Text ID des Parameters <B>paramSchnittstellePC</B>, mit <I>SchnittstellePC</I> als Schl黶sel in der Tabelle Parameter
		/// </summary>
		public const string paramSchnittstellePC = "SchnittstellePC";
		/// <summary>
		/// Text ID des Parameters <B>paramSchnittstellePort</B>, mit <I>SchnittstellePort</I> als Schl黶sel in der Tabelle Parameter
		/// </summary>
		public const string paramSchnittstellePort = "SchnittstellePort";
		/// <summary>
		/// Text ID des Parameters <B>paramSchnittstelleBaud</B>, mit <I>SchnittstelleBaud</I> als Schl黶sel in der Tabelle Parameter
		/// </summary>
		public const string paramSchnittstelleBaud = "SchnittstelleBaud";
		/// <summary>
		/// Text ID des Parameters <B>paramSchnittstelleDelay</B>, mit <I>SchnittstelleDelay</I> als Schl黶sel in der Tabelle Parameter
		/// </summary>
		public const string paramSchnittstelleDelay = "SchnittstelleDelay";
		/// <summary>
		/// Text ID des Parameters <B>paramSchnittstelleXE</B>, mit <I>SchnittstelleUltraScanXE</I> als Schl黶sel in der Tabelle Parameter
		/// </summary>
		public const string paramSchnittstelleXE = "SchnittstelleUltraScanXE";
		/// <summary>
		/// Text ID des Parameters <B>paramSchnittstelleSN</B>, mit <I>SchnittstelleSN</I> als Schl黶sel in der Tabelle Parameter
		/// </summary>
		public const string paramSchnittstelleSN = "SchnittstelleSN";
		/// <summary>
		/// Text ID des Parameters <B>paramSchnittstelleSNErmitteln</B>, mit <I>SchnittstelleSN</I> als Schl黶sel in der Tabelle Parameter
		/// </summary>
		public const string paramSchnittstelleSNErmitteln = "SchnittstelleSNErmitteln";

		/// <summary>
		/// Text ID des Parameters <B>paramDickeSchnittstelle</B>, mit <I>DickeSchnittstelle</I> als Schl黶sel in der Tabelle Parameter
		/// </summary>
		public const string paramDickeSchnittstelle = "DickeSchnittstelle";

		/// <summary>
		/// Text ID des Parameters <B>paramFadenkreuzTyp</B>, mit <I>FadenkreuzTyp</I> als Schl黶sel in der Tabelle Parameter
		/// </summary>
		public const string paramFadenkreuzTyp = "FadenkreuzTyp";

		/// <summary>
		/// Text ID des Parameters <B>paramWindowPos</B>, mit <I>WindowPosition</I> als Schl黶sel in der Tabelle Parameter
		/// </summary>
		public const string paramWindowPos = "WindowPosition";
		/// <summary>
		/// Text ID des Parameters <B>paramActiveTab</B>, mit <I>ActiveTab</I> als Schl黶sel in der Tabelle Parameter
		/// </summary>
		public const string paramActiveTab = "ActiveTab";
		/// <summary>
		/// Text ID des Parameters <B>paramFreieMessungSuchkriterien</B>, mit <I>FreieMessungSuchKriterien</I> als Schl黶sel in der Tabelle Parameter
		/// </summary>
		public const string paramFreieMessungSuchkriterien = "FreieMessungSuchKriterien";
		/// <summary>
		/// Text ID des Parameters <B>paramKommissionenSuchkriterien</B>, mit <I>KommissonenSuchKriterien</I> als Schl黶sel in der Tabelle Parameter
		/// </summary>
		public const string paramKommissionenSuchkriterien = "KommissonenSuchKriterien";
		/// <summary>
		/// Text ID des Parameters <B>paramKugelmessungenSuchkriterien</B>, mit <I>KugelmessungenSuchKriterien</I> als Schl黶sel in der Tabelle Parameter
		/// </summary>
		public const string paramKugelmessungenSuchkriterien = "KugelmessungenSuchKriterien";
		/// <summary>
		/// Text ID des Parameters <B>paramPageSettings</B>, mit <I>PageSettings</I> als Schl黶sel in der Tabelle Parameter
		/// </summary>
		public const string paramPageSettings = "PageSettings";
		/// <summary>
		/// Text ID des Parameters <B>paramAddFreieMessung</B>, mit <I>FreieMessungAdd</I> als Schl黶sel in der Tabelle Parameter
		/// </summary>
		public const string paramAddFreieMessung = "FreieMessungAdd";
		/// <summary>
		/// Text ID des Parameters <B>paramExportDecimalSeparator</B>, mit <I>ExportDecimalSeparator</I> als Schl黶sel in der Tabelle Parameter
		/// </summary>
		public const string paramExportDecimalSeparator = "ExportDecimalSeparator";
		/// <summary>
		/// Text ID des Parameters <B>paramAddWannenProzessMessung</B>, mit <I>WannenProzessMessungAdd</I> als Schl黶sel in der Tabelle Parameter
		/// </summary>
		public const string paramAddWannenProzessMessung = "WannenProzessMessungAdd";
		/// <summary>
		/// Text ID des Parameters <B>paramDichteTemparatur</B>, mit <I>DichteTemparatur</I> als Schl黶sel in der Tabelle Parameter
		/// </summary>
		public const string paramDichteTemparatur = "DichteTemparatur";
		/// <summary>
		/// Maximale Amplitude der Messungen pro Wellenl鋘ge, ab der eine Messung "ung黮tig" ist
		/// </summary>
		public const string paramMaxAmplitude = "MaximaleAmplitude";
		/// <summary>
		/// Importformat ab Dez 2004: Importiere FA-Nummer beim Artikel-Import
		/// </summary>
		public const string paramImportFANummer = "ImportFANummer";

		public const string paramImportOnline = "ImportOnline";
		public const string paramSAPSystem = "sapSystem";
		public const string paramSAPClient = "sapClient";
		public const string paramSAPUser = "sapUser";
		public const string paramSAPPassword = "sapPassword";
		public const string paramSAPLanguage = "sapLanguage";
		public const string paramSAPApplicationServer = "sapApplicationServer";
		public const string paramSAPMessageServer = "sapMessageServer";
		public const string paramSAPGatewayHost = "sapGatewayHost";
		public const string paramSAPGatewayService = "sapGatewayService";
		public const string paramSAPRouter = "sapRouter";
		public const string paramSAPPrefix = "sapPrefix";

		public const string paramImportDatum = "ImportDatum";
		public const string paramImportLog = "ImportLog";

		public const string paramExportSAP = "SAPExport";
		public const string paramAutomatikWKNR = "AutomatikWKNR";
		public const string paramWKNR = "WKNR";
		public const string paramWKNRNummerkreis = "WNUMMERNKREIS";
		public const string paramLabelPrinterPort = "LabelPrinterPort";
		public const string paramLabelLegende = "LabelLegende";
		public const string paramLabelErstmessung = "LabelErstmessung";
		public const string paramLabelSortErstmessung = "LabelSortErstmessung";
		public const string paramLabelBeurteilen = "LabelBeurteilen";

		/// <summary>
		/// Mailadresse, mit der Mails versendet werden (Absenderadresse)
		/// </summary>
		public const string paramMailAbsender = "MailAbsender";
		/// <summary>
		/// Mailadresse(n), an die Mails versendet werden
		/// </summary>
		public const string paramMailEmpfaenger = "MailEmpfaenger";
		/// <summary>
		/// Kopfzeile der Mail
		/// </summary>
		public const string paramMailKopfzeile = "MailKopfzeile";
		/// <summary>
		/// Fu遺eile der Mail
		/// </summary>
		public const string paramMailFusszeile = "MailFusszeile";
		/// <summary>
		/// Betreff (Subject) der Mail
		/// </summary>
		public const string paramMailSubject = "MailSubject";
		/// <summary>
		/// Mailserver (HOST)
		/// </summary>
		public const string paramMailServer = "MailServer";
		/// <summary>
		/// Zeitpunkt, bis zu dem Freigegebene Messungen beim Mailversand ber點ksichtigt wurde
		/// </summary>
		public const string paramMailLastDateTime = "MailLastDateTime";
		/// <summary>
		/// Benutzername zur Anmeldung am SMTP Server
		/// </summary>
		public const string paramMailUser = "MailUser";
		/// <summary>
		/// Passwort zur Anmeldung am SMTP Server
		/// </summary>
		public const string paramMailPasswort = " MailPasswort";

		/// <summary>
		/// Name der Hilfedatei. Mit "Winspek.chm" als Schl黶sel in der Tabelle Parameter
		/// </summary>
		public const string helpFile = "Winspek.chm";
	}
}

