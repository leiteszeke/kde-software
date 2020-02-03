// Decompiled with JetBrains decompiler
// Type: Konami.MainForm
// Assembly: KonamiTournamentSoftware, Version=2.0.5.2, Culture=neutral, PublicKeyToken=null
// MVID: 483A642A-5E06-4FA2-84C2-0C0BDD8D9DBE
// Assembly location: C:\Users\Ezequiel\Downloads\KDE Software\konami program 19 de noviembre 2010\KonamiTournamentSoftware.exe

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Layout;
using System.Xml;
using TournamentLibrary;
using TournamentLibrary.BusinessLogic;
using TournamentLibrary.Data_Layer;
using TournamentLibrary.Interfaces;

namespace Konami
{
  public class MainForm : Form
  {
    private Cursor _oldCursor = Cursors.Arrow;
    private DialogPrintPlayers dlgPrintPlayers = new DialogPrintPlayers();
    private DialogPrintStandings dlgPrintStandings = new DialogPrintStandings();
    private Dictionary<string, MainForm.PanelTypes> _tournamentLastViews = new Dictionary<string, MainForm.PanelTypes>();
    private Dictionary<string, PrintBatchCounts> _tournamentBatchPrintings = new Dictionary<string, PrintBatchCounts>();
    private int _maxPrintCopy = 1;
    private ITournPlayerArray _printingPlayerList = (ITournPlayerArray) new TournPlayerArray();
    private LocationArray AllLocations = new LocationArray();
    private XmlReaderSettings _xmlReaderSettings = new XmlReaderSettings();
    private XmlWriterSettings _xmlWriterSettings = new XmlWriterSettings();
    private IContainer components;
    private StatusStrip mainStatusStrip;
    private MenuStrip mainMenuStrip;
    private ToolStripMenuItem newTournamentToolStripMenuItem;
    private ToolStripMenuItem openTournamentToolStripMenuItem;
    private TabControl tabTournaments;
    private ToolStripStatusLabel toolStripStatusActivePlayers;
    private ToolStripStatusLabel toolStripStatusMatchCount;
    private ToolStripStatusLabel toolStripStatusLabel4;
    private ToolStripStatusLabel toolStripStatusCurrentRound;
    private ToolStrip mainToolStrip;
    private ToolStripLabel toolStripLabel1;
    private ToolStripButton toolStripButton1;
    private ToolStripButton toolStripButton3;
    private ToolStripButton toolStripButton2;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripButton toolStripButton4;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripLabel toolStripLabel2;
    private ToolStripButton toolStripButton7;
    private ToolStripButton toolStripButton5;
    private ToolStripButton toolStripButton6;
    private ToolStripButton toolStripButton8;
    private Label label2;
    private Label label1;
    private ListBox listNameLookup;
    private TextBox txtCurrentPlayerLastName;
    private TextBox txtCurrentPlayerFirstName;
    private Button btnEnrollPlayer;
    private ListBox listEnrolledPlayers;
    private CheckBox chkStandingsIncludeDroppedPlayers;
    private DataGridView dgStandings;
    private ComboBox ddlStandingsRound;
    private Label label5;
    private ToolStripButton toolStripButton9;
    private ToolStripMenuItem tournamentToolStripMenuItem;
    private ToolStripSeparator toolStripMenuItem1;
    private ToolStripMenuItem exportToHTMLToolStripMenuItem;
    private ToolStripMenuItem setStartingTableToolStripMenuItem;
    private ToolStripMenuItem activityLogToolStripMenuItem;
    private ToolStripSeparator toolStripMenuItem2;
    private ToolStripMenuItem fixedSeatingsToolStripMenuItem;
    private ToolStripMenuItem manualPairingsToolStripMenuItem;
    private ToolStripMenuItem pairNextRoundToolStripMenuItem;
    private ToolStripSeparator toolStripMenuItem3;
    private ToolStripMenuItem viewPlayersToolStripMenuItem;
    private ToolStripMenuItem viewPairingsToolStripMenuItem;
    private ToolStripMenuItem viewStandingsToolStripMenuItem;
    private ToolStripSeparator toolStripMenuItem4;
    private ToolStripSeparator toolStripMenuItem5;
    private ToolStripMenuItem editPenaltiesToolStripMenuItem;
    private ToolStripMenuItem editTournamentSettingsToolStripMenuItem;
    private ToolStripMenuItem viewPlayerHistoryToolStripMenuItem;
    private ToolStripSeparator toolStripMenuItem6;
    private ToolStripMenuItem printToolStripMenuItem;
    private ToolStripMenuItem printPairingsToolStripMenuItem;
    private ToolStripMenuItem printResultSlipsToolStripMenuItem;
    private ToolStripMenuItem toolsToolStripMenuItem;
    private ToolStripMenuItem preferencesToolStripMenuItem;
    private ToolStripMenuItem helpToolStripMenuItem;
    private ToolStripMenuItem aboutToolStripMenuItem;
    private ToolStripMenuItem fileToolStripMenuItem;
    private ToolStripMenuItem fileNewTournamentToolStripMenuItem;
    private ToolStripMenuItem fileOpenTournamentToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator;
    private ToolStripMenuItem fileSaveTournamentToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator4;
    private ToolStripMenuItem fileExitToolStripMenuItem;
    private ToolStripMenuItem helpToolStripMenuItem1;
    private ToolStripMenuItem aboutToolStripMenuItem1;
    private ToolStripMenuItem tournamentToolStripMenuItem1;
    private ToolStripButton btnToolStrip_ViewPlayers;
    private ToolStripButton btnToolStrip_ViewPairings;
    private ToolStripButton btnToolStrip_ViewStandings;
    private ToolStripSeparator toolStripSeparator3;
    private ToolStripButton btnToolStrip_PairRound;
    private ToolStripButton btnToolStrip_PairPlayoffs;
    private ToolStripSeparator toolStripSeparator5;
    private ToolStripButton btnToolStrip_PrintPlayers;
    private ToolStripButton btnToolStrip_PrintPairings;
    private ToolStripButton btnToolStrip_PrintResultSlips;
    private ToolStripButton btnToolStrip_PrintStandings;
    private OpenFileDialog dlgOpenFile;
    private SaveFileDialog dlgSaveFile;
    private ToolStripMenuItem tournamentUpdateSettingsToolStripMenuItem;
    private ToolStripMenuItem tournamentSetStartingTableToolStripMenuItem;
    private ContextMenuStrip subMenuMatchResult;
    private ToolStripLabel toolStripLabel3;
    private ToolStripLabel toolStripLabel4;
    private ToolStripMenuItem insertPlayer1NameWinsToolStripMenuItem;
    private ToolStripMenuItem insertPlayer2NameWinsToolStripMenuItem;
    private ToolStripMenuItem doubleLossToolStripMenuItem;
    private ToolStripLabel toolStripLabel5;
    private Label label7;
    private FolderBrowserDialog folderBrowserDialog1;
    private Button btnClearPlayer;
    private ToolStripMenuItem fileCloseTournamentToolStripMenuItem;
    private Button btnDropPlayer;
    private PrintDialog dlgPrint;
    private FontDialog dlgFontSelection;
    private Panel panelPlayerEntry;
    private Panel panelResultsEntry;
    private ComboBox ddlResultsEntryRound;
    private Label label6;
    private GroupBox groupBoxMatchResults;
    private CheckBox chkResultsPlayer2Drops;
    private CheckBox chkResultsPlayer1Drops;
    private RadioButton radioResultsDoubleLoss;
    private RadioButton radioResultsPlayer2;
    private RadioButton radioResultsPlayer1;
    private RadioButton radioResultsUnreported;
    private TextBox txtResultsEntryTable;
    private Label label3;
    private CheckBox chkHideCompletedMatches;
    private CheckBox chkViewByPlayer;
    private DataGridView dgMatches;
    private Panel panelStandings;
    private Panel panelOpenDueling;
    private PrintDocument printDocPlayerList;
    private PrintDocument printDocPairings;
    private PrintDocument printDocResultSlips;
    private PrintDocument printDocStandings;
    private TextBox txtOpenDuelingFirstname;
    private Label label9;
    private Label label8;
    private Label lblOpenDuelingHistoryData;
    private Label label10;
    private Button btnOpenDuelingMinus;
    private Button btnOpenDuelingPlus;
    private DataGridView dgOpenDueling;
    private TextBox txtOpenDuelingLastName;
    private TextBox txtCurrentPlayerID;
    private Label label4;
    private ToolStripButton btnToolStrip_RepairRound;
    private ToolStripButton btnToolStrip_CancelRound;
    private ToolStripSeparator toolStripMenuItem10;
    private ToolStripMenuItem playersToolStripMenuItem;
    private ToolStripMenuItem tournamentViewPlayersToolStripMenuItem;
    private ToolStripMenuItem pairingsToolStripMenuItem;
    private ToolStripMenuItem tournamentViewPairingsToolStripMenuItem;
    private ToolStripMenuItem standingsToolStripMenuItem;
    private ToolStripMenuItem optionsToolStripMenuItem;
    private ToolStripSeparator toolStripMenuItem11;
    private ToolStripMenuItem printPlayerListToolStripMenuItem;
    private ToolStripMenuItem tournamentViewPlayerMatchHistoryToolStripMenuItem;
    private ToolStripMenuItem tournamentPairNextRoundToolStripMenuItem;
    private ToolStripMenuItem tournamentCutToPlayoffsToolStripMenuItem;
    private ToolStripMenuItem tournamentManualPairingsToolStripMenuItem;
    private ToolStripMenuItem printPairingsByPlayerToolStripMenuItem;
    private ToolStripMenuItem printPairingsByTableToolStripMenuItem;
    private ToolStripMenuItem printResultEntrySlipsToolStripMenuItem;
    private ToolStripMenuItem printUnreportedMatchesToolStripMenuItem;
    private ToolStripMenuItem printRandomTablesToolStripMenuItem;
    private ToolStripMenuItem tournamentViewStandingsToolStripMenuItem;
    private ToolStripMenuItem printStandingsToolStripMenuItem;
    private ToolStripStatusLabel toolStripStatusLabel3;
    private ToolStripMenuItem seatAllPlayersToolStripMenuItem;
    private ToolStripMenuItem menuItemEnrollPlayersFromSeparateTournamentToolStripMenuItem;
    private ToolStripMenuItem addPlayersToGlobalListToolStripMenuItem;
    private ToolStripMenuItem verifyRepeatMatchesToolStripMenuItem;
    private ToolStripSeparator toolStripMenuItem7;
    private ToolStripSeparator toolStripMenuItem9;
    private ToolStripSeparator toolStripMenuItem12;
    private ToolStripMenuItem findPlayersPairedTwiceThisRoundToolStripMenuItem;
    private ToolStripMenuItem menuItemCurrentTournamentsToolStripMenuItem;
    private ToolStripMenuItem menuTournImportMatchResultsFromASeparateFileToolStripMenuItem;
    private ToolStripMenuItem menuItemAssignedSeatsToolStripMenuItem;
    private ToolStripMenuItem menuItemPlayerNotes;
    private ToolStripMenuItem menuItemDropPlayer;
    private ToolStripMenuItem menuItemReEnrollPlayer;
    private ToolStripSeparator toolStripMenuItem13;
    private ToolStripMenuItem setPairingsPrintoutRangesToolStripMenuItem;
    private ToolStripSeparator toolStripMenuItem14;
    private PrintDocument printDocPlayerNotes;
    private ToolStripMenuItem printPlayerNotesToolStripMenuItem;
    private ToolStripMenuItem recalcStandingsToolStripMenuItem;
    private ToolStripMenuItem menuItemChangePlayerName;
    private ToolStripButton btnToolStrip_PrintBrackets;
    private ToolStripMenuItem printBracketsToolStripMenuItem;
    private ToolStripMenuItem menuItemChangePlayerID;
    private RadioButton radioResultsDraw;
    private ContextMenuStrip subMenuEditGlobalPlayer;
    private ToolStripMenuItem subMenuGlobalPlayer_changePlayerNameToolStripMenuItem;
    private ToolStripMenuItem subMenuGlobalPlayer_changePlayerCOSSYIDToolStripMenuItem;
    private ToolStripMenuItem subMenuGlobalPlayer_deletePlayerToolStripMenuItem;
    private ToolStripMenuItem drawToolStripMenuItem;
    private Label label11;
    private Button btnAllPlayersShowAll;
    private Button btnAllPlayerSearch;
    private TextBox txtAllPlayerSearch;
    private ToolStripMenuItem subMenuGlobalPlayer_viewMatchHistoryToolStripMenuItem;
    private Label lblPlayerCount;
    private ToolStripMenuItem finalizeTournamentToolStripMenuItem;
    private ToolStripStatusLabel toolStripStatusFinalized;
    private ToolStripMenuItem subMenuGlobalPlayer_viewPLayersPenaltiesToolStripMenuItem;
    private ToolStripSeparator toolStripMenuItem15;
    private ToolStripMenuItem menuPairingsChangeMatchResultWizardToolStripMenuItem;
    private ToolStripMenuItem menuPairingsPrintPaireddownPlayersToolStripMenuItem;
    private ToolStripMenuItem menuExportGlobalPlayerlisttoCSV;
    private ToolStripMenuItem exportMatchesToCSVToolStripMenuItem;
    private ToolStripMenuItem exportPlayerlistToCSVToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator6;
    private ToolStripMenuItem menuPlayerUndropPlayerWizardToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator7;
    private ToolStripLabel toolStripLabel6;
    private ToolStripButton toolStripButton_BatchPrint;
    private ToolStripButton toolStripButton_WizardUndropPlayer;
    private ToolStripButton toolStripButton_WizardChangeResult;
    private ToolStripMenuItem menuTournamentbatchPrintingToolStripMenuItem;
    private ToolStripMenuItem menuFileShowRecentLogEntriesToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator8;
    private Button btnTempID;
    private bool showingFilteredGlobalPlayers;
    private bool TableResultKeyHandled;
    private Control _subMenuSelectedControl;
    private Engine.PrintPairingsAction _currentPairingsPrint;
    private EventHandler idleEventHandler;
    private int _currentPrintCopy;
    private int _currentPrintPage;
    private int _currentPrintPairingsRow;
    private int _currentPrintPlayerNotes;
    private int _currentPrintSplitGroup;
    private ITournMatchArray _printingMatches;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (MainForm));
      this.mainStatusStrip = new StatusStrip();
      this.toolStripStatusActivePlayers = new ToolStripStatusLabel();
      this.toolStripStatusLabel3 = new ToolStripStatusLabel();
      this.toolStripStatusMatchCount = new ToolStripStatusLabel();
      this.toolStripStatusLabel4 = new ToolStripStatusLabel();
      this.toolStripStatusCurrentRound = new ToolStripStatusLabel();
      this.toolStripStatusFinalized = new ToolStripStatusLabel();
      this.mainMenuStrip = new MenuStrip();
      this.fileToolStripMenuItem = new ToolStripMenuItem();
      this.fileNewTournamentToolStripMenuItem = new ToolStripMenuItem();
      this.fileOpenTournamentToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripSeparator = new ToolStripSeparator();
      this.fileSaveTournamentToolStripMenuItem = new ToolStripMenuItem();
      this.fileCloseTournamentToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripSeparator4 = new ToolStripSeparator();
      this.menuFileShowRecentLogEntriesToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripSeparator8 = new ToolStripSeparator();
      this.menuExportGlobalPlayerlisttoCSV = new ToolStripMenuItem();
      this.addPlayersToGlobalListToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripMenuItem10 = new ToolStripSeparator();
      this.optionsToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripMenuItem11 = new ToolStripSeparator();
      this.fileExitToolStripMenuItem = new ToolStripMenuItem();
      this.tournamentToolStripMenuItem1 = new ToolStripMenuItem();
      this.tournamentUpdateSettingsToolStripMenuItem = new ToolStripMenuItem();
      this.menuItemAssignedSeatsToolStripMenuItem = new ToolStripMenuItem();
      this.tournamentSetStartingTableToolStripMenuItem = new ToolStripMenuItem();
      this.menuTournImportMatchResultsFromASeparateFileToolStripMenuItem = new ToolStripMenuItem();
      this.finalizeTournamentToolStripMenuItem = new ToolStripMenuItem();
      this.exportMatchesToCSVToolStripMenuItem = new ToolStripMenuItem();
      this.exportPlayerlistToCSVToolStripMenuItem = new ToolStripMenuItem();
      this.menuTournamentbatchPrintingToolStripMenuItem = new ToolStripMenuItem();
      this.playersToolStripMenuItem = new ToolStripMenuItem();
      this.tournamentViewPlayersToolStripMenuItem = new ToolStripMenuItem();
      this.tournamentViewPlayerMatchHistoryToolStripMenuItem = new ToolStripMenuItem();
      this.menuItemEnrollPlayersFromSeparateTournamentToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripMenuItem9 = new ToolStripSeparator();
      this.seatAllPlayersToolStripMenuItem = new ToolStripMenuItem();
      this.printPlayerListToolStripMenuItem = new ToolStripMenuItem();
      this.findPlayersPairedTwiceThisRoundToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripMenuItem13 = new ToolStripSeparator();
      this.menuItemPlayerNotes = new ToolStripMenuItem();
      this.printPlayerNotesToolStripMenuItem = new ToolStripMenuItem();
      this.menuItemDropPlayer = new ToolStripMenuItem();
      this.menuItemReEnrollPlayer = new ToolStripMenuItem();
      this.menuItemChangePlayerName = new ToolStripMenuItem();
      this.menuItemChangePlayerID = new ToolStripMenuItem();
      this.toolStripSeparator6 = new ToolStripSeparator();
      this.menuPlayerUndropPlayerWizardToolStripMenuItem = new ToolStripMenuItem();
      this.pairingsToolStripMenuItem = new ToolStripMenuItem();
      this.tournamentViewPairingsToolStripMenuItem = new ToolStripMenuItem();
      this.tournamentPairNextRoundToolStripMenuItem = new ToolStripMenuItem();
      this.tournamentCutToPlayoffsToolStripMenuItem = new ToolStripMenuItem();
      this.tournamentManualPairingsToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripMenuItem7 = new ToolStripSeparator();
      this.printPairingsByPlayerToolStripMenuItem = new ToolStripMenuItem();
      this.printPairingsByTableToolStripMenuItem = new ToolStripMenuItem();
      this.printBracketsToolStripMenuItem = new ToolStripMenuItem();
      this.printResultEntrySlipsToolStripMenuItem = new ToolStripMenuItem();
      this.printUnreportedMatchesToolStripMenuItem = new ToolStripMenuItem();
      this.printRandomTablesToolStripMenuItem = new ToolStripMenuItem();
      this.menuPairingsPrintPaireddownPlayersToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripMenuItem14 = new ToolStripSeparator();
      this.setPairingsPrintoutRangesToolStripMenuItem = new ToolStripMenuItem();
      this.verifyRepeatMatchesToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripMenuItem15 = new ToolStripSeparator();
      this.menuPairingsChangeMatchResultWizardToolStripMenuItem = new ToolStripMenuItem();
      this.standingsToolStripMenuItem = new ToolStripMenuItem();
      this.tournamentViewStandingsToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripMenuItem12 = new ToolStripSeparator();
      this.printStandingsToolStripMenuItem = new ToolStripMenuItem();
      this.recalcStandingsToolStripMenuItem = new ToolStripMenuItem();
      this.helpToolStripMenuItem1 = new ToolStripMenuItem();
      this.aboutToolStripMenuItem1 = new ToolStripMenuItem();
      this.menuItemCurrentTournamentsToolStripMenuItem = new ToolStripMenuItem();
      this.newTournamentToolStripMenuItem = new ToolStripMenuItem();
      this.openTournamentToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripMenuItem1 = new ToolStripSeparator();
      this.exportToHTMLToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripMenuItem2 = new ToolStripSeparator();
      this.tournamentToolStripMenuItem = new ToolStripMenuItem();
      this.pairNextRoundToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripMenuItem4 = new ToolStripSeparator();
      this.viewPlayerHistoryToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripMenuItem3 = new ToolStripSeparator();
      this.viewPlayersToolStripMenuItem = new ToolStripMenuItem();
      this.viewPairingsToolStripMenuItem = new ToolStripMenuItem();
      this.viewStandingsToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripMenuItem6 = new ToolStripSeparator();
      this.manualPairingsToolStripMenuItem = new ToolStripMenuItem();
      this.fixedSeatingsToolStripMenuItem = new ToolStripMenuItem();
      this.setStartingTableToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripMenuItem5 = new ToolStripSeparator();
      this.activityLogToolStripMenuItem = new ToolStripMenuItem();
      this.editPenaltiesToolStripMenuItem = new ToolStripMenuItem();
      this.editTournamentSettingsToolStripMenuItem = new ToolStripMenuItem();
      this.printToolStripMenuItem = new ToolStripMenuItem();
      this.printPairingsToolStripMenuItem = new ToolStripMenuItem();
      this.printResultSlipsToolStripMenuItem = new ToolStripMenuItem();
      this.tabTournaments = new TabControl();
      this.btnDropPlayer = new Button();
      this.btnClearPlayer = new Button();
      this.label7 = new Label();
      this.listEnrolledPlayers = new ListBox();
      this.listNameLookup = new ListBox();
      this.txtCurrentPlayerLastName = new TextBox();
      this.txtCurrentPlayerFirstName = new TextBox();
      this.btnEnrollPlayer = new Button();
      this.label2 = new Label();
      this.label1 = new Label();
      this.ddlStandingsRound = new ComboBox();
      this.label5 = new Label();
      this.chkStandingsIncludeDroppedPlayers = new CheckBox();
      this.dgStandings = new DataGridView();
      this.mainToolStrip = new ToolStrip();
      this.toolStripLabel3 = new ToolStripLabel();
      this.btnToolStrip_ViewPlayers = new ToolStripButton();
      this.btnToolStrip_ViewPairings = new ToolStripButton();
      this.btnToolStrip_ViewStandings = new ToolStripButton();
      this.toolStripSeparator5 = new ToolStripSeparator();
      this.toolStripLabel5 = new ToolStripLabel();
      this.btnToolStrip_PrintPlayers = new ToolStripButton();
      this.btnToolStrip_PrintPairings = new ToolStripButton();
      this.btnToolStrip_PrintBrackets = new ToolStripButton();
      this.btnToolStrip_PrintResultSlips = new ToolStripButton();
      this.btnToolStrip_PrintStandings = new ToolStripButton();
      this.toolStripSeparator3 = new ToolStripSeparator();
      this.toolStripLabel4 = new ToolStripLabel();
      this.btnToolStrip_PairRound = new ToolStripButton();
      this.btnToolStrip_RepairRound = new ToolStripButton();
      this.btnToolStrip_PairPlayoffs = new ToolStripButton();
      this.btnToolStrip_CancelRound = new ToolStripButton();
      this.toolStripSeparator7 = new ToolStripSeparator();
      this.toolStripLabel6 = new ToolStripLabel();
      this.toolStripButton_BatchPrint = new ToolStripButton();
      this.toolStripButton_WizardUndropPlayer = new ToolStripButton();
      this.toolStripButton_WizardChangeResult = new ToolStripButton();
      this.toolStripLabel1 = new ToolStripLabel();
      this.toolStripButton1 = new ToolStripButton();
      this.toolStripButton2 = new ToolStripButton();
      this.toolStripButton3 = new ToolStripButton();
      this.toolStripSeparator1 = new ToolStripSeparator();
      this.toolStripButton4 = new ToolStripButton();
      this.toolStripButton9 = new ToolStripButton();
      this.toolStripSeparator2 = new ToolStripSeparator();
      this.toolStripLabel2 = new ToolStripLabel();
      this.toolStripButton7 = new ToolStripButton();
      this.toolStripButton5 = new ToolStripButton();
      this.toolStripButton6 = new ToolStripButton();
      this.toolStripButton8 = new ToolStripButton();
      this.toolsToolStripMenuItem = new ToolStripMenuItem();
      this.helpToolStripMenuItem = new ToolStripMenuItem();
      this.aboutToolStripMenuItem = new ToolStripMenuItem();
      this.preferencesToolStripMenuItem = new ToolStripMenuItem();
      this.dlgOpenFile = new OpenFileDialog();
      this.dlgSaveFile = new SaveFileDialog();
      this.subMenuMatchResult = new ContextMenuStrip(this.components);
      this.insertPlayer1NameWinsToolStripMenuItem = new ToolStripMenuItem();
      this.insertPlayer2NameWinsToolStripMenuItem = new ToolStripMenuItem();
      this.drawToolStripMenuItem = new ToolStripMenuItem();
      this.doubleLossToolStripMenuItem = new ToolStripMenuItem();
      this.folderBrowserDialog1 = new FolderBrowserDialog();
      this.dlgPrint = new PrintDialog();
      this.dlgFontSelection = new FontDialog();
      this.panelPlayerEntry = new Panel();
      this.btnTempID = new Button();
      this.lblPlayerCount = new Label();
      this.btnAllPlayersShowAll = new Button();
      this.btnAllPlayerSearch = new Button();
      this.txtAllPlayerSearch = new TextBox();
      this.label11 = new Label();
      this.txtCurrentPlayerID = new TextBox();
      this.label4 = new Label();
      this.panelResultsEntry = new Panel();
      this.ddlResultsEntryRound = new ComboBox();
      this.label6 = new Label();
      this.groupBoxMatchResults = new GroupBox();
      this.radioResultsDraw = new RadioButton();
      this.chkResultsPlayer2Drops = new CheckBox();
      this.chkResultsPlayer1Drops = new CheckBox();
      this.radioResultsDoubleLoss = new RadioButton();
      this.radioResultsPlayer2 = new RadioButton();
      this.radioResultsPlayer1 = new RadioButton();
      this.radioResultsUnreported = new RadioButton();
      this.txtResultsEntryTable = new TextBox();
      this.label3 = new Label();
      this.chkHideCompletedMatches = new CheckBox();
      this.chkViewByPlayer = new CheckBox();
      this.dgMatches = new DataGridView();
      this.panelOpenDueling = new Panel();
      this.lblOpenDuelingHistoryData = new Label();
      this.label10 = new Label();
      this.btnOpenDuelingMinus = new Button();
      this.btnOpenDuelingPlus = new Button();
      this.dgOpenDueling = new DataGridView();
      this.txtOpenDuelingLastName = new TextBox();
      this.txtOpenDuelingFirstname = new TextBox();
      this.label9 = new Label();
      this.label8 = new Label();
      this.panelStandings = new Panel();
      this.printDocPlayerList = new PrintDocument();
      this.printDocPairings = new PrintDocument();
      this.printDocResultSlips = new PrintDocument();
      this.printDocStandings = new PrintDocument();
      this.printDocPlayerNotes = new PrintDocument();
      this.subMenuEditGlobalPlayer = new ContextMenuStrip(this.components);
      this.subMenuGlobalPlayer_changePlayerNameToolStripMenuItem = new ToolStripMenuItem();
      this.subMenuGlobalPlayer_changePlayerCOSSYIDToolStripMenuItem = new ToolStripMenuItem();
      this.subMenuGlobalPlayer_deletePlayerToolStripMenuItem = new ToolStripMenuItem();
      this.subMenuGlobalPlayer_viewMatchHistoryToolStripMenuItem = new ToolStripMenuItem();
      this.subMenuGlobalPlayer_viewPLayersPenaltiesToolStripMenuItem = new ToolStripMenuItem();
      this.mainStatusStrip.SuspendLayout();
      this.mainMenuStrip.SuspendLayout();
      ((ISupportInitialize) this.dgStandings).BeginInit();
      this.mainToolStrip.SuspendLayout();
      this.subMenuMatchResult.SuspendLayout();
      this.panelPlayerEntry.SuspendLayout();
      this.panelResultsEntry.SuspendLayout();
      this.groupBoxMatchResults.SuspendLayout();
      ((ISupportInitialize) this.dgMatches).BeginInit();
      this.panelOpenDueling.SuspendLayout();
      ((ISupportInitialize) this.dgOpenDueling).BeginInit();
      this.panelStandings.SuspendLayout();
      this.subMenuEditGlobalPlayer.SuspendLayout();
      this.SuspendLayout();
      this.mainStatusStrip.Items.AddRange(new ToolStripItem[6]
      {
        (ToolStripItem) this.toolStripStatusActivePlayers,
        (ToolStripItem) this.toolStripStatusLabel3,
        (ToolStripItem) this.toolStripStatusMatchCount,
        (ToolStripItem) this.toolStripStatusLabel4,
        (ToolStripItem) this.toolStripStatusCurrentRound,
        (ToolStripItem) this.toolStripStatusFinalized
      });
      this.mainStatusStrip.Location = new Point(0, 542);
      this.mainStatusStrip.Name = "mainStatusStrip";
      this.mainStatusStrip.Size = new Size(784, 22);
      this.mainStatusStrip.TabIndex = 3;
      this.mainStatusStrip.Text = "mainStatusStrip";
      this.toolStripStatusActivePlayers.Name = "toolStripStatusActivePlayers";
      this.toolStripStatusActivePlayers.Size = new Size(114, 17);
      this.toolStripStatusActivePlayers.Text = "No Active Tournament";
      this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
      this.toolStripStatusLabel3.Size = new Size(11, 17);
      this.toolStripStatusLabel3.Text = "|";
      this.toolStripStatusMatchCount.Name = "toolStripStatusMatchCount";
      this.toolStripStatusMatchCount.Size = new Size(0, 17);
      this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
      this.toolStripStatusLabel4.Size = new Size(11, 17);
      this.toolStripStatusLabel4.Text = "|";
      this.toolStripStatusCurrentRound.Name = "toolStripStatusCurrentRound";
      this.toolStripStatusCurrentRound.Size = new Size(0, 17);
      this.toolStripStatusFinalized.Name = "toolStripStatusFinalized";
      this.toolStripStatusFinalized.Size = new Size(0, 17);
      this.mainMenuStrip.Items.AddRange(new ToolStripItem[7]
      {
        (ToolStripItem) this.fileToolStripMenuItem,
        (ToolStripItem) this.tournamentToolStripMenuItem1,
        (ToolStripItem) this.playersToolStripMenuItem,
        (ToolStripItem) this.pairingsToolStripMenuItem,
        (ToolStripItem) this.standingsToolStripMenuItem,
        (ToolStripItem) this.helpToolStripMenuItem1,
        (ToolStripItem) this.menuItemCurrentTournamentsToolStripMenuItem
      });
      this.mainMenuStrip.Location = new Point(0, 0);
      this.mainMenuStrip.Name = "mainMenuStrip";
      this.mainMenuStrip.Size = new Size(784, 24);
      this.mainMenuStrip.TabIndex = 0;
      this.mainMenuStrip.Text = "mainMenuStrip";
      this.fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[14]
      {
        (ToolStripItem) this.fileNewTournamentToolStripMenuItem,
        (ToolStripItem) this.fileOpenTournamentToolStripMenuItem,
        (ToolStripItem) this.toolStripSeparator,
        (ToolStripItem) this.fileSaveTournamentToolStripMenuItem,
        (ToolStripItem) this.fileCloseTournamentToolStripMenuItem,
        (ToolStripItem) this.toolStripSeparator4,
        (ToolStripItem) this.menuFileShowRecentLogEntriesToolStripMenuItem,
        (ToolStripItem) this.toolStripSeparator8,
        (ToolStripItem) this.menuExportGlobalPlayerlisttoCSV,
        (ToolStripItem) this.addPlayersToGlobalListToolStripMenuItem,
        (ToolStripItem) this.toolStripMenuItem10,
        (ToolStripItem) this.optionsToolStripMenuItem,
        (ToolStripItem) this.toolStripMenuItem11,
        (ToolStripItem) this.fileExitToolStripMenuItem
      });
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new Size(35, 20);
      this.fileToolStripMenuItem.Text = "&File";
      this.fileNewTournamentToolStripMenuItem.Image = (Image) componentResourceManager.GetObject("fileNewTournamentToolStripMenuItem.Image");
      this.fileNewTournamentToolStripMenuItem.ImageTransparentColor = Color.Magenta;
      this.fileNewTournamentToolStripMenuItem.Name = "fileNewTournamentToolStripMenuItem";
      this.fileNewTournamentToolStripMenuItem.ShortcutKeys = Keys.N | Keys.Control;
      this.fileNewTournamentToolStripMenuItem.Size = new Size(257, 22);
      this.fileNewTournamentToolStripMenuItem.Text = "&New Tournament";
      this.fileNewTournamentToolStripMenuItem.Click += new EventHandler(this.newToolStripMenuItem_Click);
      this.fileOpenTournamentToolStripMenuItem.Image = (Image) componentResourceManager.GetObject("fileOpenTournamentToolStripMenuItem.Image");
      this.fileOpenTournamentToolStripMenuItem.ImageTransparentColor = Color.Magenta;
      this.fileOpenTournamentToolStripMenuItem.Name = "fileOpenTournamentToolStripMenuItem";
      this.fileOpenTournamentToolStripMenuItem.ShortcutKeys = Keys.O | Keys.Control;
      this.fileOpenTournamentToolStripMenuItem.Size = new Size(257, 22);
      this.fileOpenTournamentToolStripMenuItem.Text = "&Open Tournament";
      this.fileOpenTournamentToolStripMenuItem.Click += new EventHandler(this.openToolStripMenuItem_Click);
      this.toolStripSeparator.Name = "toolStripSeparator";
      this.toolStripSeparator.Size = new Size(254, 6);
      this.fileSaveTournamentToolStripMenuItem.Image = (Image) componentResourceManager.GetObject("fileSaveTournamentToolStripMenuItem.Image");
      this.fileSaveTournamentToolStripMenuItem.ImageTransparentColor = Color.Magenta;
      this.fileSaveTournamentToolStripMenuItem.Name = "fileSaveTournamentToolStripMenuItem";
      this.fileSaveTournamentToolStripMenuItem.ShortcutKeys = Keys.S | Keys.Control;
      this.fileSaveTournamentToolStripMenuItem.Size = new Size(257, 22);
      this.fileSaveTournamentToolStripMenuItem.Text = "&Save Tournament";
      this.fileSaveTournamentToolStripMenuItem.Click += new EventHandler(this.saveToolStripMenuItem_Click);
      this.fileCloseTournamentToolStripMenuItem.Name = "fileCloseTournamentToolStripMenuItem";
      this.fileCloseTournamentToolStripMenuItem.ShortcutKeys = Keys.F4 | Keys.Control;
      this.fileCloseTournamentToolStripMenuItem.Size = new Size(257, 22);
      this.fileCloseTournamentToolStripMenuItem.Text = "Close Tournament";
      this.fileCloseTournamentToolStripMenuItem.Click += new EventHandler(this.closeTournamentToolStripMenuItem_Click);
      this.toolStripSeparator4.Name = "toolStripSeparator4";
      this.toolStripSeparator4.Size = new Size(254, 6);
      this.menuFileShowRecentLogEntriesToolStripMenuItem.Name = "menuFileShowRecentLogEntriesToolStripMenuItem";
      this.menuFileShowRecentLogEntriesToolStripMenuItem.Size = new Size(257, 22);
      this.menuFileShowRecentLogEntriesToolStripMenuItem.Text = "Show Recent Log Entries";
      this.menuFileShowRecentLogEntriesToolStripMenuItem.Click += new EventHandler(this.menuFileShowRecentLogEntriesToolStripMenuItem_Click);
      this.toolStripSeparator8.Name = "toolStripSeparator8";
      this.toolStripSeparator8.Size = new Size(254, 6);
      this.menuExportGlobalPlayerlisttoCSV.Name = "menuExportGlobalPlayerlisttoCSV";
      this.menuExportGlobalPlayerlisttoCSV.Size = new Size(257, 22);
      this.menuExportGlobalPlayerlisttoCSV.Text = "Export Global Playerlist to CSV";
      this.menuExportGlobalPlayerlisttoCSV.Click += new EventHandler(this.menuExportGlobalPlayerlisttoCSV_Click);
      this.addPlayersToGlobalListToolStripMenuItem.Name = "addPlayersToGlobalListToolStripMenuItem";
      this.addPlayersToGlobalListToolStripMenuItem.Size = new Size(257, 22);
      this.addPlayersToGlobalListToolStripMenuItem.Text = "Import Playerlist into Global Player List";
      this.addPlayersToGlobalListToolStripMenuItem.Click += new EventHandler(this.addPlayersToGlobalListToolStripMenuItem_Click);
      this.toolStripMenuItem10.Name = "toolStripMenuItem10";
      this.toolStripMenuItem10.Size = new Size(254, 6);
      this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
      this.optionsToolStripMenuItem.Size = new Size(257, 22);
      this.optionsToolStripMenuItem.Text = "&Options";
      this.optionsToolStripMenuItem.Click += new EventHandler(this.optionsToolStripMenuItem_Click);
      this.toolStripMenuItem11.Name = "toolStripMenuItem11";
      this.toolStripMenuItem11.Size = new Size(254, 6);
      this.fileExitToolStripMenuItem.Name = "fileExitToolStripMenuItem";
      this.fileExitToolStripMenuItem.Size = new Size(257, 22);
      this.fileExitToolStripMenuItem.Text = "E&xit";
      this.fileExitToolStripMenuItem.Click += new EventHandler(this.exitToolStripMenuItem_Click);
      this.tournamentToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[8]
      {
        (ToolStripItem) this.tournamentUpdateSettingsToolStripMenuItem,
        (ToolStripItem) this.menuItemAssignedSeatsToolStripMenuItem,
        (ToolStripItem) this.tournamentSetStartingTableToolStripMenuItem,
        (ToolStripItem) this.menuTournImportMatchResultsFromASeparateFileToolStripMenuItem,
        (ToolStripItem) this.finalizeTournamentToolStripMenuItem,
        (ToolStripItem) this.exportMatchesToCSVToolStripMenuItem,
        (ToolStripItem) this.exportPlayerlistToCSVToolStripMenuItem,
        (ToolStripItem) this.menuTournamentbatchPrintingToolStripMenuItem
      });
      this.tournamentToolStripMenuItem1.Name = "tournamentToolStripMenuItem1";
      this.tournamentToolStripMenuItem1.Size = new Size(77, 20);
      this.tournamentToolStripMenuItem1.Text = "Tournament";
      this.tournamentUpdateSettingsToolStripMenuItem.Name = "tournamentUpdateSettingsToolStripMenuItem";
      this.tournamentUpdateSettingsToolStripMenuItem.Size = new Size(220, 22);
      this.tournamentUpdateSettingsToolStripMenuItem.Text = "Update Settings";
      this.tournamentUpdateSettingsToolStripMenuItem.Click += new EventHandler(this.updateSettingsToolStripMenuItem_Click);
      this.menuItemAssignedSeatsToolStripMenuItem.Name = "menuItemAssignedSeatsToolStripMenuItem";
      this.menuItemAssignedSeatsToolStripMenuItem.Size = new Size(220, 22);
      this.menuItemAssignedSeatsToolStripMenuItem.Text = "Assigned Seats";
      this.menuItemAssignedSeatsToolStripMenuItem.Click += new EventHandler(this.menuItemAssignedSeatsToolStripMenuItem_Click);
      this.tournamentSetStartingTableToolStripMenuItem.Name = "tournamentSetStartingTableToolStripMenuItem";
      this.tournamentSetStartingTableToolStripMenuItem.Size = new Size(220, 22);
      this.tournamentSetStartingTableToolStripMenuItem.Text = "Set Starting Table";
      this.tournamentSetStartingTableToolStripMenuItem.Click += new EventHandler(this.tournamentSetStartingTableToolStripMenuItem_Click);
      this.menuTournImportMatchResultsFromASeparateFileToolStripMenuItem.Name = "menuTournImportMatchResultsFromASeparateFileToolStripMenuItem";
      this.menuTournImportMatchResultsFromASeparateFileToolStripMenuItem.Size = new Size(220, 22);
      this.menuTournImportMatchResultsFromASeparateFileToolStripMenuItem.Text = "Merge Round Results";
      this.menuTournImportMatchResultsFromASeparateFileToolStripMenuItem.Click += new EventHandler(this.menuTournImportMatchResultsFromASeparateFileToolStripMenuItem_Click);
      this.finalizeTournamentToolStripMenuItem.Name = "finalizeTournamentToolStripMenuItem";
      this.finalizeTournamentToolStripMenuItem.Size = new Size(220, 22);
      this.finalizeTournamentToolStripMenuItem.Text = "Finalize Tournament";
      this.finalizeTournamentToolStripMenuItem.Click += new EventHandler(this.finalizeTournamentToolStripMenuItem_Click);
      this.exportMatchesToCSVToolStripMenuItem.Name = "exportMatchesToCSVToolStripMenuItem";
      this.exportMatchesToCSVToolStripMenuItem.Size = new Size(220, 22);
      this.exportMatchesToCSVToolStripMenuItem.Text = "Export Matches to CSV";
      this.exportMatchesToCSVToolStripMenuItem.Click += new EventHandler(this.exportMatchesToCSVToolStripMenuItem_Click);
      this.exportPlayerlistToCSVToolStripMenuItem.Name = "exportPlayerlistToCSVToolStripMenuItem";
      this.exportPlayerlistToCSVToolStripMenuItem.Size = new Size(220, 22);
      this.exportPlayerlistToCSVToolStripMenuItem.Text = "Export Enrolled Players to CSV";
      this.exportPlayerlistToCSVToolStripMenuItem.Click += new EventHandler(this.exportPlayerlistToCSVToolStripMenuItem_Click);
      this.menuTournamentbatchPrintingToolStripMenuItem.Name = "menuTournamentbatchPrintingToolStripMenuItem";
      this.menuTournamentbatchPrintingToolStripMenuItem.Size = new Size(220, 22);
      this.menuTournamentbatchPrintingToolStripMenuItem.Text = "Batch Printing";
      this.menuTournamentbatchPrintingToolStripMenuItem.Click += new EventHandler(this.menuTournamentbatchPrintingToolStripMenuItem_Click);
      this.playersToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[16]
      {
        (ToolStripItem) this.tournamentViewPlayersToolStripMenuItem,
        (ToolStripItem) this.tournamentViewPlayerMatchHistoryToolStripMenuItem,
        (ToolStripItem) this.menuItemEnrollPlayersFromSeparateTournamentToolStripMenuItem,
        (ToolStripItem) this.toolStripMenuItem9,
        (ToolStripItem) this.seatAllPlayersToolStripMenuItem,
        (ToolStripItem) this.printPlayerListToolStripMenuItem,
        (ToolStripItem) this.findPlayersPairedTwiceThisRoundToolStripMenuItem,
        (ToolStripItem) this.toolStripMenuItem13,
        (ToolStripItem) this.menuItemPlayerNotes,
        (ToolStripItem) this.printPlayerNotesToolStripMenuItem,
        (ToolStripItem) this.menuItemDropPlayer,
        (ToolStripItem) this.menuItemReEnrollPlayer,
        (ToolStripItem) this.menuItemChangePlayerName,
        (ToolStripItem) this.menuItemChangePlayerID,
        (ToolStripItem) this.toolStripSeparator6,
        (ToolStripItem) this.menuPlayerUndropPlayerWizardToolStripMenuItem
      });
      this.playersToolStripMenuItem.Name = "playersToolStripMenuItem";
      this.playersToolStripMenuItem.Size = new Size(54, 20);
      this.playersToolStripMenuItem.Text = "Players";
      this.tournamentViewPlayersToolStripMenuItem.Name = "tournamentViewPlayersToolStripMenuItem";
      this.tournamentViewPlayersToolStripMenuItem.Size = new Size(246, 22);
      this.tournamentViewPlayersToolStripMenuItem.Text = "View Players";
      this.tournamentViewPlayersToolStripMenuItem.Click += new EventHandler(this.tournamentViewPlayersToolStripMenuItem_Click);
      this.tournamentViewPlayerMatchHistoryToolStripMenuItem.Name = "tournamentViewPlayerMatchHistoryToolStripMenuItem";
      this.tournamentViewPlayerMatchHistoryToolStripMenuItem.ShortcutKeys = Keys.F | Keys.Control;
      this.tournamentViewPlayerMatchHistoryToolStripMenuItem.Size = new Size(246, 22);
      this.tournamentViewPlayerMatchHistoryToolStripMenuItem.Text = "View Player Match History";
      this.tournamentViewPlayerMatchHistoryToolStripMenuItem.Click += new EventHandler(this.tournamentViewPlayerMatchHistoryToolStripMenuItem_Click);
      this.menuItemEnrollPlayersFromSeparateTournamentToolStripMenuItem.Name = "menuItemEnrollPlayersFromSeparateTournamentToolStripMenuItem";
      this.menuItemEnrollPlayersFromSeparateTournamentToolStripMenuItem.Size = new Size(246, 22);
      this.menuItemEnrollPlayersFromSeparateTournamentToolStripMenuItem.Text = "Enroll From Another Tournament";
      this.menuItemEnrollPlayersFromSeparateTournamentToolStripMenuItem.Click += new EventHandler(this.menuItemEnrollPlayersFromSeparateTournamentToolStripMenuItem_Click);
      this.toolStripMenuItem9.Name = "toolStripMenuItem9";
      this.toolStripMenuItem9.Size = new Size(243, 6);
      this.seatAllPlayersToolStripMenuItem.Name = "seatAllPlayersToolStripMenuItem";
      this.seatAllPlayersToolStripMenuItem.Size = new Size(246, 22);
      this.seatAllPlayersToolStripMenuItem.Text = "Seat All Players";
      this.seatAllPlayersToolStripMenuItem.Click += new EventHandler(this.seatAllPlayersToolStripMenuItem_Click);
      this.printPlayerListToolStripMenuItem.Name = "printPlayerListToolStripMenuItem";
      this.printPlayerListToolStripMenuItem.Size = new Size(246, 22);
      this.printPlayerListToolStripMenuItem.Text = "Print Player List";
      this.printPlayerListToolStripMenuItem.Click += new EventHandler(this.printPlayerListToolStripMenuItem_Click);
      this.findPlayersPairedTwiceThisRoundToolStripMenuItem.Name = "findPlayersPairedTwiceThisRoundToolStripMenuItem";
      this.findPlayersPairedTwiceThisRoundToolStripMenuItem.Size = new Size(246, 22);
      this.findPlayersPairedTwiceThisRoundToolStripMenuItem.Text = "Find Players Paired Twice this round";
      this.findPlayersPairedTwiceThisRoundToolStripMenuItem.Visible = false;
      this.findPlayersPairedTwiceThisRoundToolStripMenuItem.Click += new EventHandler(this.findPlayersPairedTwiceThisRoundToolStripMenuItem_Click);
      this.toolStripMenuItem13.Name = "toolStripMenuItem13";
      this.toolStripMenuItem13.Size = new Size(243, 6);
      this.menuItemPlayerNotes.Name = "menuItemPlayerNotes";
      this.menuItemPlayerNotes.Size = new Size(246, 22);
      this.menuItemPlayerNotes.Text = "Penalties";
      this.menuItemPlayerNotes.Click += new EventHandler(this.menuItemPlayerNotes_Click);
      this.printPlayerNotesToolStripMenuItem.Name = "printPlayerNotesToolStripMenuItem";
      this.printPlayerNotesToolStripMenuItem.Size = new Size(246, 22);
      this.printPlayerNotesToolStripMenuItem.Text = "Print Penalties";
      this.printPlayerNotesToolStripMenuItem.Click += new EventHandler(this.printPlayerNotesToolStripMenuItem_Click);
      this.menuItemDropPlayer.Name = "menuItemDropPlayer";
      this.menuItemDropPlayer.Size = new Size(246, 22);
      this.menuItemDropPlayer.Text = "Drop Player";
      this.menuItemDropPlayer.Click += new EventHandler(this.menuItemDropPlayer_Click);
      this.menuItemReEnrollPlayer.Name = "menuItemReEnrollPlayer";
      this.menuItemReEnrollPlayer.Size = new Size(246, 22);
      this.menuItemReEnrollPlayer.Text = "Re-Enroll Player";
      this.menuItemReEnrollPlayer.Click += new EventHandler(this.menuItemReEnrollPlayer_Click);
      this.menuItemChangePlayerName.Name = "menuItemChangePlayerName";
      this.menuItemChangePlayerName.Size = new Size(246, 22);
      this.menuItemChangePlayerName.Text = "Change Player Name";
      this.menuItemChangePlayerName.Click += new EventHandler(this.menuItemChangePlayerName_Click);
      this.menuItemChangePlayerID.Name = "menuItemChangePlayerID";
      this.menuItemChangePlayerID.Size = new Size(246, 22);
      this.menuItemChangePlayerID.Text = "Change Player ID";
      this.menuItemChangePlayerID.Click += new EventHandler(this.menuItemChangePlayerID_Click);
      this.toolStripSeparator6.Name = "toolStripSeparator6";
      this.toolStripSeparator6.Size = new Size(243, 6);
      this.menuPlayerUndropPlayerWizardToolStripMenuItem.Name = "menuPlayerUndropPlayerWizardToolStripMenuItem";
      this.menuPlayerUndropPlayerWizardToolStripMenuItem.Size = new Size(246, 22);
      this.menuPlayerUndropPlayerWizardToolStripMenuItem.Text = "Undrop Player Wizard";
      this.menuPlayerUndropPlayerWizardToolStripMenuItem.Click += new EventHandler(this.menuPlayerUndropPlayerWizardToolStripMenuItem_Click);
      this.pairingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[17]
      {
        (ToolStripItem) this.tournamentViewPairingsToolStripMenuItem,
        (ToolStripItem) this.tournamentPairNextRoundToolStripMenuItem,
        (ToolStripItem) this.tournamentCutToPlayoffsToolStripMenuItem,
        (ToolStripItem) this.tournamentManualPairingsToolStripMenuItem,
        (ToolStripItem) this.toolStripMenuItem7,
        (ToolStripItem) this.printPairingsByPlayerToolStripMenuItem,
        (ToolStripItem) this.printPairingsByTableToolStripMenuItem,
        (ToolStripItem) this.printBracketsToolStripMenuItem,
        (ToolStripItem) this.printResultEntrySlipsToolStripMenuItem,
        (ToolStripItem) this.printUnreportedMatchesToolStripMenuItem,
        (ToolStripItem) this.printRandomTablesToolStripMenuItem,
        (ToolStripItem) this.menuPairingsPrintPaireddownPlayersToolStripMenuItem,
        (ToolStripItem) this.toolStripMenuItem14,
        (ToolStripItem) this.setPairingsPrintoutRangesToolStripMenuItem,
        (ToolStripItem) this.verifyRepeatMatchesToolStripMenuItem,
        (ToolStripItem) this.toolStripMenuItem15,
        (ToolStripItem) this.menuPairingsChangeMatchResultWizardToolStripMenuItem
      });
      this.pairingsToolStripMenuItem.Name = "pairingsToolStripMenuItem";
      this.pairingsToolStripMenuItem.Size = new Size(56, 20);
      this.pairingsToolStripMenuItem.Text = "Pairings";
      this.tournamentViewPairingsToolStripMenuItem.Name = "tournamentViewPairingsToolStripMenuItem";
      this.tournamentViewPairingsToolStripMenuItem.Size = new Size(212, 22);
      this.tournamentViewPairingsToolStripMenuItem.Text = "View Pairings";
      this.tournamentViewPairingsToolStripMenuItem.Click += new EventHandler(this.tournamentViewPairingsToolStripMenuItem_Click);
      this.tournamentPairNextRoundToolStripMenuItem.Name = "tournamentPairNextRoundToolStripMenuItem";
      this.tournamentPairNextRoundToolStripMenuItem.Size = new Size(212, 22);
      this.tournamentPairNextRoundToolStripMenuItem.Text = "Pair Next Round";
      this.tournamentPairNextRoundToolStripMenuItem.Click += new EventHandler(this.pairNextRoundToolStripMenuItem1_Click);
      this.tournamentCutToPlayoffsToolStripMenuItem.Name = "tournamentCutToPlayoffsToolStripMenuItem";
      this.tournamentCutToPlayoffsToolStripMenuItem.Size = new Size(212, 22);
      this.tournamentCutToPlayoffsToolStripMenuItem.Text = "Cut to Playoffs";
      this.tournamentCutToPlayoffsToolStripMenuItem.Click += new EventHandler(this.tournamentCutToPlayoffsToolStripMenuItem_Click);
      this.tournamentManualPairingsToolStripMenuItem.Name = "tournamentManualPairingsToolStripMenuItem";
      this.tournamentManualPairingsToolStripMenuItem.Size = new Size(212, 22);
      this.tournamentManualPairingsToolStripMenuItem.Text = "Manual Pairings";
      this.tournamentManualPairingsToolStripMenuItem.Click += new EventHandler(this.manualPairingsToolStripMenuItem1_Click);
      this.toolStripMenuItem7.Name = "toolStripMenuItem7";
      this.toolStripMenuItem7.Size = new Size(209, 6);
      this.printPairingsByPlayerToolStripMenuItem.Name = "printPairingsByPlayerToolStripMenuItem";
      this.printPairingsByPlayerToolStripMenuItem.Size = new Size(212, 22);
      this.printPairingsByPlayerToolStripMenuItem.Text = "Print Pairings by Player";
      this.printPairingsByPlayerToolStripMenuItem.Click += new EventHandler(this.pairingsByPlayerToolStripMenuItem_Click);
      this.printPairingsByTableToolStripMenuItem.Name = "printPairingsByTableToolStripMenuItem";
      this.printPairingsByTableToolStripMenuItem.Size = new Size(212, 22);
      this.printPairingsByTableToolStripMenuItem.Text = "Print Pairings by Table";
      this.printPairingsByTableToolStripMenuItem.Click += new EventHandler(this.pairingsByTableToolStripMenuItem_Click);
      this.printBracketsToolStripMenuItem.Name = "printBracketsToolStripMenuItem";
      this.printBracketsToolStripMenuItem.Size = new Size(212, 22);
      this.printBracketsToolStripMenuItem.Text = "Print Brackets";
      this.printBracketsToolStripMenuItem.Click += new EventHandler(this.printBracketsToolStripMenuItem_Click);
      this.printResultEntrySlipsToolStripMenuItem.Name = "printResultEntrySlipsToolStripMenuItem";
      this.printResultEntrySlipsToolStripMenuItem.Size = new Size(212, 22);
      this.printResultEntrySlipsToolStripMenuItem.Text = "Print Match Result Slips";
      this.printResultEntrySlipsToolStripMenuItem.Click += new EventHandler(this.printResultEntrySlipsToolStripMenuItem_Click);
      this.printUnreportedMatchesToolStripMenuItem.Name = "printUnreportedMatchesToolStripMenuItem";
      this.printUnreportedMatchesToolStripMenuItem.Size = new Size(212, 22);
      this.printUnreportedMatchesToolStripMenuItem.Text = "Print Unreported Matches";
      this.printUnreportedMatchesToolStripMenuItem.Click += new EventHandler(this.printUnreportedMatchesToolStripMenuItem_Click);
      this.printRandomTablesToolStripMenuItem.Name = "printRandomTablesToolStripMenuItem";
      this.printRandomTablesToolStripMenuItem.Size = new Size(212, 22);
      this.printRandomTablesToolStripMenuItem.Text = "Print Random Matches";
      this.printRandomTablesToolStripMenuItem.Click += new EventHandler(this.printRandomTablesToolStripMenuItem_Click);
      this.menuPairingsPrintPaireddownPlayersToolStripMenuItem.Name = "menuPairingsPrintPaireddownPlayersToolStripMenuItem";
      this.menuPairingsPrintPaireddownPlayersToolStripMenuItem.Size = new Size(212, 22);
      this.menuPairingsPrintPaireddownPlayersToolStripMenuItem.Text = "Print Paired-down Players";
      this.menuPairingsPrintPaireddownPlayersToolStripMenuItem.Click += new EventHandler(this.menuPairingsPrintPaireddownPlayersToolStripMenuItem_Click);
      this.toolStripMenuItem14.Name = "toolStripMenuItem14";
      this.toolStripMenuItem14.Size = new Size(209, 6);
      this.setPairingsPrintoutRangesToolStripMenuItem.Name = "setPairingsPrintoutRangesToolStripMenuItem";
      this.setPairingsPrintoutRangesToolStripMenuItem.Size = new Size(212, 22);
      this.setPairingsPrintoutRangesToolStripMenuItem.Text = "Set Pairings Printout Ranges";
      this.setPairingsPrintoutRangesToolStripMenuItem.Click += new EventHandler(this.setPairingsPrintoutRangesToolStripMenuItem_Click);
      this.verifyRepeatMatchesToolStripMenuItem.Name = "verifyRepeatMatchesToolStripMenuItem";
      this.verifyRepeatMatchesToolStripMenuItem.Size = new Size(212, 22);
      this.verifyRepeatMatchesToolStripMenuItem.Text = "Verify Repeat Matches";
      this.verifyRepeatMatchesToolStripMenuItem.Visible = false;
      this.verifyRepeatMatchesToolStripMenuItem.Click += new EventHandler(this.verifyRepeatMatchesToolStripMenuItem_Click);
      this.toolStripMenuItem15.Name = "toolStripMenuItem15";
      this.toolStripMenuItem15.Size = new Size(209, 6);
      this.menuPairingsChangeMatchResultWizardToolStripMenuItem.Name = "menuPairingsChangeMatchResultWizardToolStripMenuItem";
      this.menuPairingsChangeMatchResultWizardToolStripMenuItem.Size = new Size(212, 22);
      this.menuPairingsChangeMatchResultWizardToolStripMenuItem.Text = "Change Match Result Wizard";
      this.menuPairingsChangeMatchResultWizardToolStripMenuItem.Click += new EventHandler(this.menuPairingsChangeMatchResultWizardToolStripMenuItem_Click);
      this.standingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[4]
      {
        (ToolStripItem) this.tournamentViewStandingsToolStripMenuItem,
        (ToolStripItem) this.toolStripMenuItem12,
        (ToolStripItem) this.printStandingsToolStripMenuItem,
        (ToolStripItem) this.recalcStandingsToolStripMenuItem
      });
      this.standingsToolStripMenuItem.Name = "standingsToolStripMenuItem";
      this.standingsToolStripMenuItem.Size = new Size(66, 20);
      this.standingsToolStripMenuItem.Text = "Standings";
      this.tournamentViewStandingsToolStripMenuItem.Name = "tournamentViewStandingsToolStripMenuItem";
      this.tournamentViewStandingsToolStripMenuItem.Size = new Size(155, 22);
      this.tournamentViewStandingsToolStripMenuItem.Text = "View Standings";
      this.tournamentViewStandingsToolStripMenuItem.Click += new EventHandler(this.tournamentViewStandingsToolStripMenuItem_Click);
      this.toolStripMenuItem12.Name = "toolStripMenuItem12";
      this.toolStripMenuItem12.Size = new Size(152, 6);
      this.printStandingsToolStripMenuItem.Name = "printStandingsToolStripMenuItem";
      this.printStandingsToolStripMenuItem.Size = new Size(155, 22);
      this.printStandingsToolStripMenuItem.Text = "Print Standings";
      this.printStandingsToolStripMenuItem.Click += new EventHandler(this.printStandingsToolStripMenuItem_Click);
      this.recalcStandingsToolStripMenuItem.Name = "recalcStandingsToolStripMenuItem";
      this.recalcStandingsToolStripMenuItem.Size = new Size(155, 22);
      this.recalcStandingsToolStripMenuItem.Text = "Recalc Standings";
      this.recalcStandingsToolStripMenuItem.Visible = false;
      this.recalcStandingsToolStripMenuItem.Click += new EventHandler(this.recalcStandingsToolStripMenuItem_Click);
      this.helpToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.aboutToolStripMenuItem1
      });
      this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
      this.helpToolStripMenuItem1.Size = new Size(40, 20);
      this.helpToolStripMenuItem1.Text = "&Help";
      this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
      this.aboutToolStripMenuItem1.Size = new Size(115, 22);
      this.aboutToolStripMenuItem1.Text = "&About...";
      this.aboutToolStripMenuItem1.Click += new EventHandler(this.aboutToolStripMenuItem1_Click);
      this.menuItemCurrentTournamentsToolStripMenuItem.Name = "menuItemCurrentTournamentsToolStripMenuItem";
      this.menuItemCurrentTournamentsToolStripMenuItem.Size = new Size(122, 20);
      this.menuItemCurrentTournamentsToolStripMenuItem.Text = "Current Tournaments";
      this.newTournamentToolStripMenuItem.Name = "newTournamentToolStripMenuItem";
      this.newTournamentToolStripMenuItem.Size = new Size(172, 22);
      this.newTournamentToolStripMenuItem.Text = "New Tournament";
      this.newTournamentToolStripMenuItem.Click += new EventHandler(this.newTournamentToolStripMenuItem_Click);
      this.openTournamentToolStripMenuItem.Name = "openTournamentToolStripMenuItem";
      this.openTournamentToolStripMenuItem.Size = new Size(172, 22);
      this.openTournamentToolStripMenuItem.Text = "Open Tournament";
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new Size(169, 6);
      this.exportToHTMLToolStripMenuItem.Name = "exportToHTMLToolStripMenuItem";
      this.exportToHTMLToolStripMenuItem.Size = new Size(172, 22);
      this.exportToHTMLToolStripMenuItem.Text = "Export to HTML";
      this.toolStripMenuItem2.Name = "toolStripMenuItem2";
      this.toolStripMenuItem2.Size = new Size(169, 6);
      this.tournamentToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[15]
      {
        (ToolStripItem) this.pairNextRoundToolStripMenuItem,
        (ToolStripItem) this.toolStripMenuItem4,
        (ToolStripItem) this.viewPlayerHistoryToolStripMenuItem,
        (ToolStripItem) this.toolStripMenuItem3,
        (ToolStripItem) this.viewPlayersToolStripMenuItem,
        (ToolStripItem) this.viewPairingsToolStripMenuItem,
        (ToolStripItem) this.viewStandingsToolStripMenuItem,
        (ToolStripItem) this.toolStripMenuItem6,
        (ToolStripItem) this.manualPairingsToolStripMenuItem,
        (ToolStripItem) this.fixedSeatingsToolStripMenuItem,
        (ToolStripItem) this.setStartingTableToolStripMenuItem,
        (ToolStripItem) this.toolStripMenuItem5,
        (ToolStripItem) this.activityLogToolStripMenuItem,
        (ToolStripItem) this.editPenaltiesToolStripMenuItem,
        (ToolStripItem) this.editTournamentSettingsToolStripMenuItem
      });
      this.tournamentToolStripMenuItem.Name = "tournamentToolStripMenuItem";
      this.tournamentToolStripMenuItem.Size = new Size(85, 20);
      this.tournamentToolStripMenuItem.Text = "Tournament";
      this.pairNextRoundToolStripMenuItem.Name = "pairNextRoundToolStripMenuItem";
      this.pairNextRoundToolStripMenuItem.Size = new Size(195, 22);
      this.pairNextRoundToolStripMenuItem.Text = "Pair Next Round";
      this.toolStripMenuItem4.Name = "toolStripMenuItem4";
      this.toolStripMenuItem4.Size = new Size(192, 6);
      this.viewPlayerHistoryToolStripMenuItem.Name = "viewPlayerHistoryToolStripMenuItem";
      this.viewPlayerHistoryToolStripMenuItem.Size = new Size(195, 22);
      this.viewPlayerHistoryToolStripMenuItem.Text = "View Player History";
      this.toolStripMenuItem3.Name = "toolStripMenuItem3";
      this.toolStripMenuItem3.Size = new Size(192, 6);
      this.viewPlayersToolStripMenuItem.Name = "viewPlayersToolStripMenuItem";
      this.viewPlayersToolStripMenuItem.Size = new Size(195, 22);
      this.viewPlayersToolStripMenuItem.Text = "View Players";
      this.viewPairingsToolStripMenuItem.Name = "viewPairingsToolStripMenuItem";
      this.viewPairingsToolStripMenuItem.Size = new Size(195, 22);
      this.viewPairingsToolStripMenuItem.Text = "View Pairings";
      this.viewStandingsToolStripMenuItem.Name = "viewStandingsToolStripMenuItem";
      this.viewStandingsToolStripMenuItem.Size = new Size(195, 22);
      this.viewStandingsToolStripMenuItem.Text = "View Standings";
      this.toolStripMenuItem6.Name = "toolStripMenuItem6";
      this.toolStripMenuItem6.Size = new Size(192, 6);
      this.manualPairingsToolStripMenuItem.Name = "manualPairingsToolStripMenuItem";
      this.manualPairingsToolStripMenuItem.Size = new Size(195, 22);
      this.manualPairingsToolStripMenuItem.Text = "Manually Edit Pairings";
      this.fixedSeatingsToolStripMenuItem.Name = "fixedSeatingsToolStripMenuItem";
      this.fixedSeatingsToolStripMenuItem.Size = new Size(195, 22);
      this.fixedSeatingsToolStripMenuItem.Text = "Fixed Seatings";
      this.setStartingTableToolStripMenuItem.Name = "setStartingTableToolStripMenuItem";
      this.setStartingTableToolStripMenuItem.Size = new Size(195, 22);
      this.setStartingTableToolStripMenuItem.Text = "Set starting table";
      this.toolStripMenuItem5.Name = "toolStripMenuItem5";
      this.toolStripMenuItem5.Size = new Size(192, 6);
      this.activityLogToolStripMenuItem.Name = "activityLogToolStripMenuItem";
      this.activityLogToolStripMenuItem.Size = new Size(195, 22);
      this.activityLogToolStripMenuItem.Text = "View Activity Log";
      this.editPenaltiesToolStripMenuItem.Name = "editPenaltiesToolStripMenuItem";
      this.editPenaltiesToolStripMenuItem.Size = new Size(195, 22);
      this.editPenaltiesToolStripMenuItem.Text = "Edit Penalties";
      this.editTournamentSettingsToolStripMenuItem.Name = "editTournamentSettingsToolStripMenuItem";
      this.editTournamentSettingsToolStripMenuItem.Size = new Size(195, 22);
      this.editTournamentSettingsToolStripMenuItem.Text = "Edit Tournament Settings";
      this.printToolStripMenuItem.Name = "printToolStripMenuItem";
      this.printToolStripMenuItem.Size = new Size(32, 19);
      this.printPairingsToolStripMenuItem.Name = "printPairingsToolStripMenuItem";
      this.printPairingsToolStripMenuItem.Size = new Size(210, 22);
      this.printPairingsToolStripMenuItem.Text = "Print Pairings by Player";
      this.printResultSlipsToolStripMenuItem.Name = "printResultSlipsToolStripMenuItem";
      this.printResultSlipsToolStripMenuItem.Size = new Size(210, 22);
      this.printResultSlipsToolStripMenuItem.Text = "Print Result Slips";
      this.tabTournaments.Dock = DockStyle.Top;
      this.tabTournaments.ItemSize = new Size(78, 16);
      this.tabTournaments.Location = new Point(0, 49);
      this.tabTournaments.Multiline = true;
      this.tabTournaments.Name = "tabTournaments";
      this.tabTournaments.SelectedIndex = 0;
      this.tabTournaments.Size = new Size(784, 25);
      this.tabTournaments.SizeMode = TabSizeMode.FillToRight;
      this.tabTournaments.TabIndex = 2;
      this.tabTournaments.ControlAdded += new ControlEventHandler(this.tabTournaments_ControlAdded);
      this.tabTournaments.SelectedIndexChanged += new EventHandler(this.tabTournaments_SelectedIndexChanged);
      this.tabTournaments.ControlRemoved += new ControlEventHandler(this.tabTournaments_ControlRemoved);
      this.btnDropPlayer.Location = new Point(271, 101);
      this.btnDropPlayer.Name = "btnDropPlayer";
      this.btnDropPlayer.Size = new Size(62, 23);
      this.btnDropPlayer.TabIndex = 8;
      this.btnDropPlayer.Text = "Drop";
      this.btnDropPlayer.UseVisualStyleBackColor = true;
      this.btnDropPlayer.Click += new EventHandler(this.btnDropPlayer_Click);
      this.btnClearPlayer.Location = new Point(136, 101);
      this.btnClearPlayer.Name = "btnClearPlayer";
      this.btnClearPlayer.Size = new Size(62, 23);
      this.btnClearPlayer.TabIndex = 6;
      this.btnClearPlayer.Text = "Clear";
      this.btnClearPlayer.UseVisualStyleBackColor = true;
      this.btnClearPlayer.Click += new EventHandler(this.btnClearPlayer_Click);
      this.label7.AutoSize = true;
      this.label7.Location = new Point(377, 12);
      this.label7.Name = "label7";
      this.label7.Size = new Size(85, 13);
      this.label7.TabIndex = 9;
      this.label7.Text = "Enrolled Players:";
      this.listEnrolledPlayers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.listEnrolledPlayers.FormattingEnabled = true;
      this.listEnrolledPlayers.Location = new Point(380, 42);
      this.listEnrolledPlayers.Name = "listEnrolledPlayers";
      this.listEnrolledPlayers.Size = new Size(357, 485);
      this.listEnrolledPlayers.Sorted = true;
      this.listEnrolledPlayers.TabIndex = 13;
      this.listEnrolledPlayers.SelectedIndexChanged += new EventHandler(this.listEnrolledPlayers_SelectedIndexChanged);
      this.listEnrolledPlayers.DoubleClick += new EventHandler(this.listEnrolledPlayers_DoubleClick);
      this.listEnrolledPlayers.MouseDown += new MouseEventHandler(this.listEnrolledPlayers_MouseDown);
      this.listNameLookup.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      this.listNameLookup.FormattingEnabled = true;
      this.listNameLookup.Location = new Point(19, 198);
      this.listNameLookup.Name = "listNameLookup";
      this.listNameLookup.Size = new Size(314, 316);
      this.listNameLookup.Sorted = true;
      this.listNameLookup.TabIndex = 12;
      this.listNameLookup.SelectedIndexChanged += new EventHandler(this.listNameLookup_SelectedIndexChanged);
      this.listNameLookup.DoubleClick += new EventHandler(this.listNameLookup_DoubleClick);
      this.listNameLookup.MouseDown += new MouseEventHandler(this.listNameLookup_MouseDown);
      this.txtCurrentPlayerLastName.Location = new Point(83, 65);
      this.txtCurrentPlayerLastName.Name = "txtCurrentPlayerLastName";
      this.txtCurrentPlayerLastName.ReadOnly = true;
      this.txtCurrentPlayerLastName.Size = new Size(250, 20);
      this.txtCurrentPlayerLastName.TabIndex = 5;
      this.txtCurrentPlayerLastName.KeyUp += new KeyEventHandler(this.txtCurrentPlayerLastName_KeyUp);
      this.txtCurrentPlayerFirstName.Location = new Point(83, 39);
      this.txtCurrentPlayerFirstName.Name = "txtCurrentPlayerFirstName";
      this.txtCurrentPlayerFirstName.ReadOnly = true;
      this.txtCurrentPlayerFirstName.Size = new Size(250, 20);
      this.txtCurrentPlayerFirstName.TabIndex = 3;
      this.txtCurrentPlayerFirstName.KeyUp += new KeyEventHandler(this.txtCurrentPlayerFirstName_KeyUp);
      this.btnEnrollPlayer.Location = new Point(204, 101);
      this.btnEnrollPlayer.Name = "btnEnrollPlayer";
      this.btnEnrollPlayer.Size = new Size(62, 23);
      this.btnEnrollPlayer.TabIndex = 7;
      this.btnEnrollPlayer.Text = "Enroll";
      this.btnEnrollPlayer.UseVisualStyleBackColor = true;
      this.btnEnrollPlayer.Click += new EventHandler(this.btnEnrollPlayer_Click);
      this.label2.AutoSize = true;
      this.label2.Location = new Point(16, 68);
      this.label2.Name = "label2";
      this.label2.Size = new Size(61, 13);
      this.label2.TabIndex = 4;
      this.label2.Text = "Last Name:";
      this.label1.AutoSize = true;
      this.label1.Location = new Point(17, 42);
      this.label1.Name = "label1";
      this.label1.Size = new Size(60, 13);
      this.label1.TabIndex = 2;
      this.label1.Text = "First Name:";
      this.ddlStandingsRound.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ddlStandingsRound.FormattingEnabled = true;
      this.ddlStandingsRound.Location = new Point(429, 24);
      this.ddlStandingsRound.Name = "ddlStandingsRound";
      this.ddlStandingsRound.Size = new Size(139, 21);
      this.ddlStandingsRound.TabIndex = 2;
      this.ddlStandingsRound.SelectedIndexChanged += new EventHandler(this.ddlStandingsRound_SelectedIndexChanged);
      this.label5.AutoSize = true;
      this.label5.Location = new Point(381, 26);
      this.label5.Name = "label5";
      this.label5.Size = new Size(42, 13);
      this.label5.TabIndex = 1;
      this.label5.Text = "Round:";
      this.chkStandingsIncludeDroppedPlayers.AutoSize = true;
      this.chkStandingsIncludeDroppedPlayers.Location = new Point(123, 26);
      this.chkStandingsIncludeDroppedPlayers.Name = "chkStandingsIncludeDroppedPlayers";
      this.chkStandingsIncludeDroppedPlayers.Size = new Size(142, 17);
      this.chkStandingsIncludeDroppedPlayers.TabIndex = 0;
      this.chkStandingsIncludeDroppedPlayers.Text = "Include Dropped Players";
      this.chkStandingsIncludeDroppedPlayers.UseVisualStyleBackColor = true;
      this.chkStandingsIncludeDroppedPlayers.CheckedChanged += new EventHandler(this.chkStandingsIncludeDroppedPlayers_CheckedChanged);
      this.dgStandings.AllowUserToAddRows = false;
      this.dgStandings.AllowUserToDeleteRows = false;
      this.dgStandings.AllowUserToResizeRows = false;
      this.dgStandings.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgStandings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
      this.dgStandings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgStandings.Location = new Point(37, 65);
      this.dgStandings.Name = "dgStandings";
      this.dgStandings.ReadOnly = true;
      this.dgStandings.RowHeadersVisible = false;
      this.dgStandings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dgStandings.Size = new Size(623, 478);
      this.dgStandings.TabIndex = 3;
      this.mainToolStrip.Items.AddRange(new ToolStripItem[22]
      {
        (ToolStripItem) this.toolStripLabel3,
        (ToolStripItem) this.btnToolStrip_ViewPlayers,
        (ToolStripItem) this.btnToolStrip_ViewPairings,
        (ToolStripItem) this.btnToolStrip_ViewStandings,
        (ToolStripItem) this.toolStripSeparator5,
        (ToolStripItem) this.toolStripLabel5,
        (ToolStripItem) this.btnToolStrip_PrintPlayers,
        (ToolStripItem) this.btnToolStrip_PrintPairings,
        (ToolStripItem) this.btnToolStrip_PrintBrackets,
        (ToolStripItem) this.btnToolStrip_PrintResultSlips,
        (ToolStripItem) this.btnToolStrip_PrintStandings,
        (ToolStripItem) this.toolStripSeparator3,
        (ToolStripItem) this.toolStripLabel4,
        (ToolStripItem) this.btnToolStrip_PairRound,
        (ToolStripItem) this.btnToolStrip_RepairRound,
        (ToolStripItem) this.btnToolStrip_PairPlayoffs,
        (ToolStripItem) this.btnToolStrip_CancelRound,
        (ToolStripItem) this.toolStripSeparator7,
        (ToolStripItem) this.toolStripLabel6,
        (ToolStripItem) this.toolStripButton_BatchPrint,
        (ToolStripItem) this.toolStripButton_WizardUndropPlayer,
        (ToolStripItem) this.toolStripButton_WizardChangeResult
      });
      this.mainToolStrip.Location = new Point(0, 24);
      this.mainToolStrip.Name = "mainToolStrip";
      this.mainToolStrip.Size = new Size(784, 25);
      this.mainToolStrip.TabIndex = 1;
      this.mainToolStrip.Text = "toolStrip1";
      this.toolStripLabel3.Name = "toolStripLabel3";
      this.toolStripLabel3.Size = new Size(33, 22);
      this.toolStripLabel3.Text = "View:";
      this.btnToolStrip_ViewPlayers.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.btnToolStrip_ViewPlayers.Image = (Image) componentResourceManager.GetObject("btnToolStrip_ViewPlayers.Image");
      this.btnToolStrip_ViewPlayers.ImageTransparentColor = Color.Magenta;
      this.btnToolStrip_ViewPlayers.Name = "btnToolStrip_ViewPlayers";
      this.btnToolStrip_ViewPlayers.Size = new Size(23, 22);
      this.btnToolStrip_ViewPlayers.ToolTipText = "View Players";
      this.btnToolStrip_ViewPlayers.Click += new EventHandler(this.btnToolStrip_ViewPlayers_Click);
      this.btnToolStrip_ViewPairings.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.btnToolStrip_ViewPairings.Image = (Image) componentResourceManager.GetObject("btnToolStrip_ViewPairings.Image");
      this.btnToolStrip_ViewPairings.ImageTransparentColor = Color.Magenta;
      this.btnToolStrip_ViewPairings.Name = "btnToolStrip_ViewPairings";
      this.btnToolStrip_ViewPairings.Size = new Size(23, 22);
      this.btnToolStrip_ViewPairings.ToolTipText = "View Pairings";
      this.btnToolStrip_ViewPairings.Click += new EventHandler(this.btnToolStrip_ViewPairings_Click);
      this.btnToolStrip_ViewStandings.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.btnToolStrip_ViewStandings.Image = (Image) componentResourceManager.GetObject("btnToolStrip_ViewStandings.Image");
      this.btnToolStrip_ViewStandings.ImageTransparentColor = Color.Magenta;
      this.btnToolStrip_ViewStandings.Name = "btnToolStrip_ViewStandings";
      this.btnToolStrip_ViewStandings.Size = new Size(23, 22);
      this.btnToolStrip_ViewStandings.ToolTipText = "View Standings";
      this.btnToolStrip_ViewStandings.Click += new EventHandler(this.btnToolStrip_ViewStandings_Click);
      this.toolStripSeparator5.Name = "toolStripSeparator5";
      this.toolStripSeparator5.Size = new Size(6, 25);
      this.toolStripLabel5.Name = "toolStripLabel5";
      this.toolStripLabel5.Size = new Size(33, 22);
      this.toolStripLabel5.Text = "Print:";
      this.btnToolStrip_PrintPlayers.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.btnToolStrip_PrintPlayers.Image = (Image) componentResourceManager.GetObject("btnToolStrip_PrintPlayers.Image");
      this.btnToolStrip_PrintPlayers.ImageTransparentColor = Color.Magenta;
      this.btnToolStrip_PrintPlayers.Name = "btnToolStrip_PrintPlayers";
      this.btnToolStrip_PrintPlayers.Size = new Size(23, 22);
      this.btnToolStrip_PrintPlayers.ToolTipText = "Print Players";
      this.btnToolStrip_PrintPlayers.Click += new EventHandler(this.btnToolStrip_PrintPlayers_Click);
      this.btnToolStrip_PrintPairings.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.btnToolStrip_PrintPairings.Image = (Image) componentResourceManager.GetObject("btnToolStrip_PrintPairings.Image");
      this.btnToolStrip_PrintPairings.ImageTransparentColor = Color.Magenta;
      this.btnToolStrip_PrintPairings.Name = "btnToolStrip_PrintPairings";
      this.btnToolStrip_PrintPairings.Size = new Size(23, 22);
      this.btnToolStrip_PrintPairings.ToolTipText = "Print Pairings";
      this.btnToolStrip_PrintPairings.Click += new EventHandler(this.btnToolStrip_PrintPairings_Click);
      this.btnToolStrip_PrintBrackets.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.btnToolStrip_PrintBrackets.Image = (Image) componentResourceManager.GetObject("btnToolStrip_PrintBrackets.Image");
      this.btnToolStrip_PrintBrackets.ImageTransparentColor = Color.Magenta;
      this.btnToolStrip_PrintBrackets.Name = "btnToolStrip_PrintBrackets";
      this.btnToolStrip_PrintBrackets.Size = new Size(23, 22);
      this.btnToolStrip_PrintBrackets.ToolTipText = "Print Brackets";
      this.btnToolStrip_PrintBrackets.Click += new EventHandler(this.btnToolStrip_PrintBrackets_Click);
      this.btnToolStrip_PrintResultSlips.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.btnToolStrip_PrintResultSlips.Image = (Image) componentResourceManager.GetObject("btnToolStrip_PrintResultSlips.Image");
      this.btnToolStrip_PrintResultSlips.ImageTransparentColor = Color.Magenta;
      this.btnToolStrip_PrintResultSlips.Name = "btnToolStrip_PrintResultSlips";
      this.btnToolStrip_PrintResultSlips.Size = new Size(23, 22);
      this.btnToolStrip_PrintResultSlips.ToolTipText = "Print Result Slips";
      this.btnToolStrip_PrintResultSlips.Click += new EventHandler(this.btnToolStrip_PrintResultSlips_Click);
      this.btnToolStrip_PrintStandings.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.btnToolStrip_PrintStandings.Image = (Image) componentResourceManager.GetObject("btnToolStrip_PrintStandings.Image");
      this.btnToolStrip_PrintStandings.ImageTransparentColor = Color.Magenta;
      this.btnToolStrip_PrintStandings.Name = "btnToolStrip_PrintStandings";
      this.btnToolStrip_PrintStandings.Size = new Size(23, 22);
      this.btnToolStrip_PrintStandings.ToolTipText = "Print Standings";
      this.btnToolStrip_PrintStandings.Click += new EventHandler(this.btnToolStrip_PrintStandings_Click);
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new Size(6, 25);
      this.toolStripLabel4.Name = "toolStripLabel4";
      this.toolStripLabel4.Size = new Size(29, 22);
      this.toolStripLabel4.Text = "Pair:";
      this.btnToolStrip_PairRound.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.btnToolStrip_PairRound.Image = (Image) componentResourceManager.GetObject("btnToolStrip_PairRound.Image");
      this.btnToolStrip_PairRound.ImageTransparentColor = Color.Magenta;
      this.btnToolStrip_PairRound.Name = "btnToolStrip_PairRound";
      this.btnToolStrip_PairRound.Size = new Size(23, 22);
      this.btnToolStrip_PairRound.ToolTipText = "Pair Round";
      this.btnToolStrip_PairRound.Click += new EventHandler(this.btnToolStrip_PairRound_Click);
      this.btnToolStrip_RepairRound.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.btnToolStrip_RepairRound.Image = (Image) componentResourceManager.GetObject("btnToolStrip_RepairRound.Image");
      this.btnToolStrip_RepairRound.ImageTransparentColor = Color.Magenta;
      this.btnToolStrip_RepairRound.Name = "btnToolStrip_RepairRound";
      this.btnToolStrip_RepairRound.Size = new Size(23, 22);
      this.btnToolStrip_RepairRound.ToolTipText = "Re-Pair Round";
      this.btnToolStrip_RepairRound.Click += new EventHandler(this.btnToolStrip_RepairRound_Click);
      this.btnToolStrip_PairPlayoffs.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.btnToolStrip_PairPlayoffs.Image = (Image) componentResourceManager.GetObject("btnToolStrip_PairPlayoffs.Image");
      this.btnToolStrip_PairPlayoffs.ImageTransparentColor = Color.Magenta;
      this.btnToolStrip_PairPlayoffs.Name = "btnToolStrip_PairPlayoffs";
      this.btnToolStrip_PairPlayoffs.Size = new Size(23, 22);
      this.btnToolStrip_PairPlayoffs.ToolTipText = "Pair Playoffs";
      this.btnToolStrip_PairPlayoffs.Click += new EventHandler(this.btnToolStrip_PairPlayoffs_Click);
      this.btnToolStrip_CancelRound.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.btnToolStrip_CancelRound.Image = (Image) componentResourceManager.GetObject("btnToolStrip_CancelRound.Image");
      this.btnToolStrip_CancelRound.ImageTransparentColor = Color.Magenta;
      this.btnToolStrip_CancelRound.Name = "btnToolStrip_CancelRound";
      this.btnToolStrip_CancelRound.Size = new Size(23, 22);
      this.btnToolStrip_CancelRound.ToolTipText = "Cancel Round";
      this.btnToolStrip_CancelRound.Click += new EventHandler(this.btnToolStrip_CancelRound_Click);
      this.toolStripSeparator7.Name = "toolStripSeparator7";
      this.toolStripSeparator7.Size = new Size(6, 25);
      this.toolStripLabel6.Name = "toolStripLabel6";
      this.toolStripLabel6.Size = new Size(49, 22);
      this.toolStripLabel6.Text = "Wizards:";
      this.toolStripButton_BatchPrint.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButton_BatchPrint.Image = (Image) componentResourceManager.GetObject("toolStripButton_BatchPrint.Image");
      this.toolStripButton_BatchPrint.ImageTransparentColor = Color.Magenta;
      this.toolStripButton_BatchPrint.Name = "toolStripButton_BatchPrint";
      this.toolStripButton_BatchPrint.Size = new Size(23, 22);
      this.toolStripButton_BatchPrint.ToolTipText = "Batch Printing";
      this.toolStripButton_BatchPrint.Click += new EventHandler(this.toolStripButton_BatchPrint_Click);
      this.toolStripButton_WizardUndropPlayer.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButton_WizardUndropPlayer.Image = (Image) componentResourceManager.GetObject("toolStripButton_WizardUndropPlayer.Image");
      this.toolStripButton_WizardUndropPlayer.ImageTransparentColor = Color.Magenta;
      this.toolStripButton_WizardUndropPlayer.Name = "toolStripButton_WizardUndropPlayer";
      this.toolStripButton_WizardUndropPlayer.Size = new Size(23, 22);
      this.toolStripButton_WizardUndropPlayer.ToolTipText = "Un-Drop Player Wizard";
      this.toolStripButton_WizardUndropPlayer.Click += new EventHandler(this.toolStripButton_WizardUndropPlayer_Click);
      this.toolStripButton_WizardChangeResult.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButton_WizardChangeResult.Image = (Image) componentResourceManager.GetObject("toolStripButton_WizardChangeResult.Image");
      this.toolStripButton_WizardChangeResult.ImageTransparentColor = Color.Magenta;
      this.toolStripButton_WizardChangeResult.Name = "toolStripButton_WizardChangeResult";
      this.toolStripButton_WizardChangeResult.Size = new Size(23, 22);
      this.toolStripButton_WizardChangeResult.ToolTipText = "Change Match Result Wizard";
      this.toolStripButton_WizardChangeResult.Click += new EventHandler(this.toolStripButton_WizardChangeResult_Click);
      this.toolStripLabel1.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripLabel1.Image = (Image) componentResourceManager.GetObject("toolStripLabel1.Image");
      this.toolStripLabel1.Margin = new Padding(2, 1, 2, 2);
      this.toolStripLabel1.Name = "toolStripLabel1";
      this.toolStripLabel1.Size = new Size(16, 22);
      this.toolStripLabel1.Text = "View:";
      this.toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButton1.Image = (Image) componentResourceManager.GetObject("toolStripButton1.Image");
      this.toolStripButton1.ImageTransparentColor = Color.Magenta;
      this.toolStripButton1.Name = "toolStripButton1";
      this.toolStripButton1.Size = new Size(23, 22);
      this.toolStripButton1.Text = "Players";
      this.toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButton2.Image = (Image) componentResourceManager.GetObject("toolStripButton2.Image");
      this.toolStripButton2.ImageTransparentColor = Color.Magenta;
      this.toolStripButton2.Name = "toolStripButton2";
      this.toolStripButton2.Size = new Size(23, 22);
      this.toolStripButton2.Text = "Pairings";
      this.toolStripButton3.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButton3.Image = (Image) componentResourceManager.GetObject("toolStripButton3.Image");
      this.toolStripButton3.ImageTransparentColor = Color.Magenta;
      this.toolStripButton3.Name = "toolStripButton3";
      this.toolStripButton3.Size = new Size(23, 22);
      this.toolStripButton3.Text = "Standings";
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new Size(6, 25);
      this.toolStripButton4.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButton4.Image = (Image) componentResourceManager.GetObject("toolStripButton4.Image");
      this.toolStripButton4.ImageTransparentColor = Color.Magenta;
      this.toolStripButton4.Name = "toolStripButton4";
      this.toolStripButton4.Size = new Size(23, 22);
      this.toolStripButton4.Text = "Pair Round";
      this.toolStripButton9.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButton9.Image = (Image) componentResourceManager.GetObject("toolStripButton9.Image");
      this.toolStripButton9.ImageTransparentColor = Color.Magenta;
      this.toolStripButton9.Name = "toolStripButton9";
      this.toolStripButton9.Size = new Size(23, 22);
      this.toolStripButton9.Text = "Playoffs";
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new Size(6, 25);
      this.toolStripLabel2.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripLabel2.Image = (Image) componentResourceManager.GetObject("toolStripLabel2.Image");
      this.toolStripLabel2.Margin = new Padding(2, 1, 2, 2);
      this.toolStripLabel2.Name = "toolStripLabel2";
      this.toolStripLabel2.Size = new Size(16, 22);
      this.toolStripLabel2.Text = "Print:";
      this.toolStripButton7.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButton7.Image = (Image) componentResourceManager.GetObject("toolStripButton7.Image");
      this.toolStripButton7.ImageTransparentColor = Color.Magenta;
      this.toolStripButton7.Name = "toolStripButton7";
      this.toolStripButton7.Size = new Size(23, 22);
      this.toolStripButton7.Text = "Players";
      this.toolStripButton5.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButton5.Image = (Image) componentResourceManager.GetObject("toolStripButton5.Image");
      this.toolStripButton5.ImageTransparentColor = Color.Magenta;
      this.toolStripButton5.Name = "toolStripButton5";
      this.toolStripButton5.Size = new Size(23, 22);
      this.toolStripButton5.Text = "Pairings";
      this.toolStripButton6.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButton6.Image = (Image) componentResourceManager.GetObject("toolStripButton6.Image");
      this.toolStripButton6.ImageTransparentColor = Color.Magenta;
      this.toolStripButton6.Name = "toolStripButton6";
      this.toolStripButton6.Size = new Size(23, 22);
      this.toolStripButton6.Text = "Slips";
      this.toolStripButton8.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButton8.Image = (Image) componentResourceManager.GetObject("toolStripButton8.Image");
      this.toolStripButton8.ImageTransparentColor = Color.Magenta;
      this.toolStripButton8.Name = "toolStripButton8";
      this.toolStripButton8.Size = new Size(23, 22);
      this.toolStripButton8.Text = "Standings";
      this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
      this.toolsToolStripMenuItem.Size = new Size(48, 20);
      this.toolsToolStripMenuItem.Text = "&Tools";
      this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
      this.helpToolStripMenuItem.Size = new Size(44, 20);
      this.helpToolStripMenuItem.Text = "&Help";
      this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
      this.aboutToolStripMenuItem.Size = new Size(152, 22);
      this.aboutToolStripMenuItem.Text = "&About...";
      this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
      this.preferencesToolStripMenuItem.Size = new Size(152, 22);
      this.preferencesToolStripMenuItem.Text = "Preferences";
      this.subMenuMatchResult.Items.AddRange(new ToolStripItem[4]
      {
        (ToolStripItem) this.insertPlayer1NameWinsToolStripMenuItem,
        (ToolStripItem) this.insertPlayer2NameWinsToolStripMenuItem,
        (ToolStripItem) this.drawToolStripMenuItem,
        (ToolStripItem) this.doubleLossToolStripMenuItem
      });
      this.subMenuMatchResult.Name = "subMenuMatchResult";
      this.subMenuMatchResult.ShowImageMargin = false;
      this.subMenuMatchResult.Size = new Size(193, 92);
      this.insertPlayer1NameWinsToolStripMenuItem.Name = "insertPlayer1NameWinsToolStripMenuItem";
      this.insertPlayer1NameWinsToolStripMenuItem.Size = new Size(192, 22);
      this.insertPlayer1NameWinsToolStripMenuItem.Text = "<Insert Player 1 Name> Wins";
      this.insertPlayer1NameWinsToolStripMenuItem.Click += new EventHandler(this.insertPlayer1NameWinsToolStripMenuItem_Click);
      this.insertPlayer2NameWinsToolStripMenuItem.Name = "insertPlayer2NameWinsToolStripMenuItem";
      this.insertPlayer2NameWinsToolStripMenuItem.Size = new Size(192, 22);
      this.insertPlayer2NameWinsToolStripMenuItem.Text = "<Insert Player 2 Name> Wins";
      this.insertPlayer2NameWinsToolStripMenuItem.Click += new EventHandler(this.insertPlayer2NameWinsToolStripMenuItem_Click);
      this.drawToolStripMenuItem.Name = "drawToolStripMenuItem";
      this.drawToolStripMenuItem.Size = new Size(192, 22);
      this.drawToolStripMenuItem.Text = "Draw";
      this.drawToolStripMenuItem.Click += new EventHandler(this.drawToolStripMenuItem_Click);
      this.doubleLossToolStripMenuItem.Name = "doubleLossToolStripMenuItem";
      this.doubleLossToolStripMenuItem.Size = new Size(192, 22);
      this.doubleLossToolStripMenuItem.Text = "Double Loss";
      this.doubleLossToolStripMenuItem.Click += new EventHandler(this.doubleLossToolStripMenuItem_Click);
      this.dlgPrint.AllowSomePages = true;
      this.dlgPrint.UseEXDialog = true;
      this.panelPlayerEntry.Controls.Add((Control) this.btnTempID);
      this.panelPlayerEntry.Controls.Add((Control) this.lblPlayerCount);
      this.panelPlayerEntry.Controls.Add((Control) this.btnAllPlayersShowAll);
      this.panelPlayerEntry.Controls.Add((Control) this.btnAllPlayerSearch);
      this.panelPlayerEntry.Controls.Add((Control) this.txtAllPlayerSearch);
      this.panelPlayerEntry.Controls.Add((Control) this.label11);
      this.panelPlayerEntry.Controls.Add((Control) this.txtCurrentPlayerID);
      this.panelPlayerEntry.Controls.Add((Control) this.label4);
      this.panelPlayerEntry.Controls.Add((Control) this.label1);
      this.panelPlayerEntry.Controls.Add((Control) this.btnDropPlayer);
      this.panelPlayerEntry.Controls.Add((Control) this.label2);
      this.panelPlayerEntry.Controls.Add((Control) this.btnClearPlayer);
      this.panelPlayerEntry.Controls.Add((Control) this.btnEnrollPlayer);
      this.panelPlayerEntry.Controls.Add((Control) this.label7);
      this.panelPlayerEntry.Controls.Add((Control) this.txtCurrentPlayerFirstName);
      this.panelPlayerEntry.Controls.Add((Control) this.txtCurrentPlayerLastName);
      this.panelPlayerEntry.Controls.Add((Control) this.listNameLookup);
      this.panelPlayerEntry.Controls.Add((Control) this.listEnrolledPlayers);
      this.panelPlayerEntry.Dock = DockStyle.Fill;
      this.panelPlayerEntry.Location = new Point(0, 0);
      this.panelPlayerEntry.Name = "panelPlayerEntry";
      this.panelPlayerEntry.Size = new Size(784, 564);
      this.panelPlayerEntry.TabIndex = 3;
      this.panelPlayerEntry.VisibleChanged += new EventHandler(this.panelPlayerEntry_VisibleChanged);
      this.btnTempID.Location = new Point(216, 10);
      this.btnTempID.Name = "btnTempID";
      this.btnTempID.Size = new Size(62, 23);
      this.btnTempID.TabIndex = 2;
      this.btnTempID.Text = "Temp ID";
      this.btnTempID.UseVisualStyleBackColor = true;
      this.btnTempID.Click += new EventHandler(this.btnTempID_Click);
      this.lblPlayerCount.AutoSize = true;
      this.lblPlayerCount.Location = new Point(19, 144);
      this.lblPlayerCount.Name = "lblPlayerCount";
      this.lblPlayerCount.Size = new Size(0, 13);
      this.lblPlayerCount.TabIndex = 15;
      this.btnAllPlayersShowAll.Location = new Point(271, 162);
      this.btnAllPlayersShowAll.Name = "btnAllPlayersShowAll";
      this.btnAllPlayersShowAll.Size = new Size(62, 23);
      this.btnAllPlayersShowAll.TabIndex = 11;
      this.btnAllPlayersShowAll.Text = "Show All";
      this.btnAllPlayersShowAll.UseVisualStyleBackColor = true;
      this.btnAllPlayersShowAll.Click += new EventHandler(this.btnAllPlayersShowAll_Click);
      this.btnAllPlayerSearch.Location = new Point(204, 162);
      this.btnAllPlayerSearch.Name = "btnAllPlayerSearch";
      this.btnAllPlayerSearch.Size = new Size(62, 23);
      this.btnAllPlayerSearch.TabIndex = 10;
      this.btnAllPlayerSearch.Text = "Search";
      this.btnAllPlayerSearch.UseVisualStyleBackColor = true;
      this.btnAllPlayerSearch.Click += new EventHandler(this.btnAllPlayerSearch_Click);
      this.txtAllPlayerSearch.Location = new Point(71, 165);
      this.txtAllPlayerSearch.Name = "txtAllPlayerSearch";
      this.txtAllPlayerSearch.Size = new Size((int) sbyte.MaxValue, 20);
      this.txtAllPlayerSearch.TabIndex = 9;
      this.txtAllPlayerSearch.KeyPress += new KeyPressEventHandler(this.txtAllPlayerSearch_KeyPress);
      this.label11.AutoSize = true;
      this.label11.Location = new Point(21, 168);
      this.label11.Name = "label11";
      this.label11.Size = new Size(44, 13);
      this.label11.TabIndex = 14;
      this.label11.Text = "Search:";
      this.txtCurrentPlayerID.BackColor = SystemColors.Window;
      this.txtCurrentPlayerID.Location = new Point(83, 13);
      this.txtCurrentPlayerID.MaxLength = 10;
      this.txtCurrentPlayerID.Name = "txtCurrentPlayerID";
      this.txtCurrentPlayerID.Size = new Size(116, 20);
      this.txtCurrentPlayerID.TabIndex = 1;
      this.txtCurrentPlayerID.TextChanged += new EventHandler(this.txtCurrentPlayerID_TextChanged);
      this.txtCurrentPlayerID.KeyPress += new KeyPressEventHandler(this.txtCurrentPlayerID_KeyPress);
      this.label4.AutoSize = true;
      this.label4.Location = new Point(17, 16);
      this.label4.Name = "label4";
      this.label4.Size = new Size(21, 13);
      this.label4.TabIndex = 0;
      this.label4.Text = "ID:";
      this.panelResultsEntry.Controls.Add((Control) this.ddlResultsEntryRound);
      this.panelResultsEntry.Controls.Add((Control) this.label6);
      this.panelResultsEntry.Controls.Add((Control) this.groupBoxMatchResults);
      this.panelResultsEntry.Controls.Add((Control) this.txtResultsEntryTable);
      this.panelResultsEntry.Controls.Add((Control) this.label3);
      this.panelResultsEntry.Controls.Add((Control) this.chkHideCompletedMatches);
      this.panelResultsEntry.Controls.Add((Control) this.chkViewByPlayer);
      this.panelResultsEntry.Controls.Add((Control) this.dgMatches);
      this.panelResultsEntry.Dock = DockStyle.Fill;
      this.panelResultsEntry.Location = new Point(0, 0);
      this.panelResultsEntry.Name = "panelResultsEntry";
      this.panelResultsEntry.Size = new Size(784, 564);
      this.panelResultsEntry.TabIndex = 0;
      this.panelResultsEntry.VisibleChanged += new EventHandler(this.panelResultsEntry_VisibleChanged);
      this.ddlResultsEntryRound.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.ddlResultsEntryRound.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ddlResultsEntryRound.FormattingEnabled = true;
      this.ddlResultsEntryRound.Items.AddRange(new object[4]
      {
        (object) "4 (Current)",
        (object) "3",
        (object) "2",
        (object) "1"
      });
      this.ddlResultsEntryRound.Location = new Point(616, 15);
      this.ddlResultsEntryRound.Name = "ddlResultsEntryRound";
      this.ddlResultsEntryRound.Size = new Size(139, 21);
      this.ddlResultsEntryRound.TabIndex = 12;
      this.ddlResultsEntryRound.SelectedIndexChanged += new EventHandler(this.ddlResultsEntryRound_SelectedIndexChanged);
      this.label6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.label6.AutoSize = true;
      this.label6.Location = new Point(568, 17);
      this.label6.Name = "label6";
      this.label6.Size = new Size(42, 13);
      this.label6.TabIndex = 11;
      this.label6.Text = "Round:";
      this.groupBoxMatchResults.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.groupBoxMatchResults.Controls.Add((Control) this.radioResultsDraw);
      this.groupBoxMatchResults.Controls.Add((Control) this.chkResultsPlayer2Drops);
      this.groupBoxMatchResults.Controls.Add((Control) this.chkResultsPlayer1Drops);
      this.groupBoxMatchResults.Controls.Add((Control) this.radioResultsDoubleLoss);
      this.groupBoxMatchResults.Controls.Add((Control) this.radioResultsPlayer2);
      this.groupBoxMatchResults.Controls.Add((Control) this.radioResultsPlayer1);
      this.groupBoxMatchResults.Controls.Add((Control) this.radioResultsUnreported);
      this.groupBoxMatchResults.Location = new Point(567, 95);
      this.groupBoxMatchResults.Name = "groupBoxMatchResults";
      this.groupBoxMatchResults.Size = new Size(203, 235);
      this.groupBoxMatchResults.TabIndex = 15;
      this.groupBoxMatchResults.TabStop = false;
      this.groupBoxMatchResults.Text = "Match Results";
      this.radioResultsDraw.AutoSize = true;
      this.radioResultsDraw.Location = new Point(17, 73);
      this.radioResultsDraw.Name = "radioResultsDraw";
      this.radioResultsDraw.Size = new Size(63, 17);
      this.radioResultsDraw.TabIndex = 3;
      this.radioResultsDraw.TabStop = true;
      this.radioResultsDraw.Text = "Draw (*)";
      this.radioResultsDraw.UseVisualStyleBackColor = true;
      this.radioResultsDraw.Click += new EventHandler(this.radioResultsDraw_Click);
      this.chkResultsPlayer2Drops.AutoSize = true;
      this.chkResultsPlayer2Drops.Location = new Point(17, 177);
      this.chkResultsPlayer2Drops.Name = "chkResultsPlayer2Drops";
      this.chkResultsPlayer2Drops.Size = new Size(107, 17);
      this.chkResultsPlayer2Drops.TabIndex = 7;
      this.chkResultsPlayer2Drops.Text = "<Player 2> Drops";
      this.chkResultsPlayer2Drops.UseVisualStyleBackColor = true;
      this.chkResultsPlayer2Drops.Click += new EventHandler(this.chkResultsPlayer2Drops_Click);
      this.chkResultsPlayer1Drops.AutoSize = true;
      this.chkResultsPlayer1Drops.Location = new Point(17, 154);
      this.chkResultsPlayer1Drops.Name = "chkResultsPlayer1Drops";
      this.chkResultsPlayer1Drops.Size = new Size(107, 17);
      this.chkResultsPlayer1Drops.TabIndex = 6;
      this.chkResultsPlayer1Drops.Text = "<Player 1> Drops";
      this.chkResultsPlayer1Drops.UseVisualStyleBackColor = true;
      this.chkResultsPlayer1Drops.Click += new EventHandler(this.chkResultsPlayer1Drops_Click);
      this.radioResultsDoubleLoss.AutoSize = true;
      this.radioResultsDoubleLoss.Location = new Point(17, 96);
      this.radioResultsDoubleLoss.Name = "radioResultsDoubleLoss";
      this.radioResultsDoubleLoss.Size = new Size(104, 17);
      this.radioResultsDoubleLoss.TabIndex = 4;
      this.radioResultsDoubleLoss.TabStop = true;
      this.radioResultsDoubleLoss.Text = "Double Loss ( / )";
      this.radioResultsDoubleLoss.UseVisualStyleBackColor = true;
      this.radioResultsDoubleLoss.Click += new EventHandler(this.radioResultsDoubleLoss_Click);
      this.radioResultsPlayer2.AutoSize = true;
      this.radioResultsPlayer2.Location = new Point(17, 49);
      this.radioResultsPlayer2.Name = "radioResultsPlayer2";
      this.radioResultsPlayer2.Size = new Size(123, 17);
      this.radioResultsPlayer2.TabIndex = 1;
      this.radioResultsPlayer2.TabStop = true;
      this.radioResultsPlayer2.Text = "<Player 2> Wins ( + )";
      this.radioResultsPlayer2.UseVisualStyleBackColor = true;
      this.radioResultsPlayer2.Click += new EventHandler(this.radioResultsPlayer2_Click);
      this.radioResultsPlayer1.AutoSize = true;
      this.radioResultsPlayer1.Location = new Point(17, 24);
      this.radioResultsPlayer1.Name = "radioResultsPlayer1";
      this.radioResultsPlayer1.Size = new Size(120, 17);
      this.radioResultsPlayer1.TabIndex = 0;
      this.radioResultsPlayer1.TabStop = true;
      this.radioResultsPlayer1.Text = "<Player 1> Wins ( - )";
      this.radioResultsPlayer1.UseVisualStyleBackColor = true;
      this.radioResultsPlayer1.Click += new EventHandler(this.radioResultsPlayer1_Click);
      this.radioResultsUnreported.AutoSize = true;
      this.radioResultsUnreported.Location = new Point(17, 121);
      this.radioResultsUnreported.Name = "radioResultsUnreported";
      this.radioResultsUnreported.Size = new Size(78, 17);
      this.radioResultsUnreported.TabIndex = 5;
      this.radioResultsUnreported.TabStop = true;
      this.radioResultsUnreported.Text = "Unreported";
      this.radioResultsUnreported.UseVisualStyleBackColor = true;
      this.radioResultsUnreported.Click += new EventHandler(this.radioResultsUnreported_Click);
      this.txtResultsEntryTable.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtResultsEntryTable.Location = new Point(663, 61);
      this.txtResultsEntryTable.Name = "txtResultsEntryTable";
      this.txtResultsEntryTable.Size = new Size(55, 20);
      this.txtResultsEntryTable.TabIndex = 14;
      this.txtResultsEntryTable.KeyUp += new KeyEventHandler(this.txtResultsEntryTable_KeyUp);
      this.txtResultsEntryTable.KeyPress += new KeyPressEventHandler(this.txtResultsEntryTable_KeyPress);
      this.label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.label3.AutoSize = true;
      this.label3.Location = new Point(613, 64);
      this.label3.Name = "label3";
      this.label3.Size = new Size(34, 13);
      this.label3.TabIndex = 13;
      this.label3.Text = "Table";
      this.chkHideCompletedMatches.AutoSize = true;
      this.chkHideCompletedMatches.Location = new Point(147, 16);
      this.chkHideCompletedMatches.Name = "chkHideCompletedMatches";
      this.chkHideCompletedMatches.Size = new Size(145, 17);
      this.chkHideCompletedMatches.TabIndex = 9;
      this.chkHideCompletedMatches.Text = "Hide Completed Matches";
      this.chkHideCompletedMatches.UseVisualStyleBackColor = true;
      this.chkHideCompletedMatches.CheckedChanged += new EventHandler(this.chkHideCompletedMatches_CheckedChanged);
      this.chkViewByPlayer.AutoSize = true;
      this.chkViewByPlayer.Location = new Point(23, 16);
      this.chkViewByPlayer.Name = "chkViewByPlayer";
      this.chkViewByPlayer.Size = new Size(95, 17);
      this.chkViewByPlayer.TabIndex = 8;
      this.chkViewByPlayer.Text = "View by Player";
      this.chkViewByPlayer.UseVisualStyleBackColor = true;
      this.chkViewByPlayer.CheckedChanged += new EventHandler(this.chkViewByPlayer_CheckedChanged);
      this.dgMatches.AllowUserToAddRows = false;
      this.dgMatches.AllowUserToDeleteRows = false;
      this.dgMatches.AllowUserToResizeRows = false;
      this.dgMatches.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgMatches.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.dgMatches.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      this.dgMatches.ContextMenuStrip = this.subMenuMatchResult;
      this.dgMatches.Location = new Point(23, 46);
      this.dgMatches.MultiSelect = false;
      this.dgMatches.Name = "dgMatches";
      this.dgMatches.ReadOnly = true;
      this.dgMatches.RowHeadersVisible = false;
      this.dgMatches.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dgMatches.Size = new Size(519, 500);
      this.dgMatches.TabIndex = 10;
      this.dgMatches.CellContextMenuStripNeeded += new DataGridViewCellContextMenuStripNeededEventHandler(this.dgMatches_CellContextMenuStripNeeded);
      this.dgMatches.KeyPress += new KeyPressEventHandler(this.dgMatches_KeyPress);
      this.dgMatches.KeyUp += new KeyEventHandler(this.dgMatches_KeyUp);
      this.dgMatches.RowStateChanged += new DataGridViewRowStateChangedEventHandler(this.dgMatches_RowStateChanged);
      this.panelOpenDueling.Controls.Add((Control) this.lblOpenDuelingHistoryData);
      this.panelOpenDueling.Controls.Add((Control) this.label10);
      this.panelOpenDueling.Controls.Add((Control) this.btnOpenDuelingMinus);
      this.panelOpenDueling.Controls.Add((Control) this.btnOpenDuelingPlus);
      this.panelOpenDueling.Controls.Add((Control) this.dgOpenDueling);
      this.panelOpenDueling.Controls.Add((Control) this.txtOpenDuelingLastName);
      this.panelOpenDueling.Controls.Add((Control) this.txtOpenDuelingFirstname);
      this.panelOpenDueling.Controls.Add((Control) this.label9);
      this.panelOpenDueling.Controls.Add((Control) this.label8);
      this.panelOpenDueling.Dock = DockStyle.Fill;
      this.panelOpenDueling.Location = new Point(0, 0);
      this.panelOpenDueling.Name = "panelOpenDueling";
      this.panelOpenDueling.Size = new Size(784, 564);
      this.panelOpenDueling.TabIndex = 14;
      this.lblOpenDuelingHistoryData.AutoSize = true;
      this.lblOpenDuelingHistoryData.Location = new Point(536, 126);
      this.lblOpenDuelingHistoryData.Name = "lblOpenDuelingHistoryData";
      this.lblOpenDuelingHistoryData.Size = new Size(0, 13);
      this.lblOpenDuelingHistoryData.TabIndex = 8;
      this.label10.AutoSize = true;
      this.label10.Location = new Point(533, 90);
      this.label10.Name = "label10";
      this.label10.Size = new Size(42, 13);
      this.label10.TabIndex = 7;
      this.label10.Text = "History:";
      this.btnOpenDuelingMinus.Location = new Point(662, 26);
      this.btnOpenDuelingMinus.Name = "btnOpenDuelingMinus";
      this.btnOpenDuelingMinus.Size = new Size(38, 23);
      this.btnOpenDuelingMinus.TabIndex = 6;
      this.btnOpenDuelingMinus.Text = "-";
      this.btnOpenDuelingMinus.UseVisualStyleBackColor = true;
      this.btnOpenDuelingMinus.Click += new EventHandler(this.btnOpenDuelingMinus_Click);
      this.btnOpenDuelingPlus.Location = new Point(609, 26);
      this.btnOpenDuelingPlus.Name = "btnOpenDuelingPlus";
      this.btnOpenDuelingPlus.Size = new Size(38, 23);
      this.btnOpenDuelingPlus.TabIndex = 5;
      this.btnOpenDuelingPlus.Text = "+";
      this.btnOpenDuelingPlus.UseVisualStyleBackColor = true;
      this.btnOpenDuelingPlus.Click += new EventHandler(this.btnOpenDuelingPlus_Click);
      this.dgOpenDueling.AllowUserToAddRows = false;
      this.dgOpenDueling.AllowUserToDeleteRows = false;
      this.dgOpenDueling.AllowUserToResizeRows = false;
      this.dgOpenDueling.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
      this.dgOpenDueling.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgOpenDueling.Location = new Point(49, 75);
      this.dgOpenDueling.MultiSelect = false;
      this.dgOpenDueling.Name = "dgOpenDueling";
      this.dgOpenDueling.ReadOnly = true;
      this.dgOpenDueling.RowHeadersVisible = false;
      this.dgOpenDueling.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dgOpenDueling.Size = new Size(449, 348);
      this.dgOpenDueling.TabIndex = 4;
      this.dgOpenDueling.KeyDown += new KeyEventHandler(this.dgOpenDueling_KeyDown);
      this.dgOpenDueling.SelectionChanged += new EventHandler(this.dgOpenDueling_SelectionChanged);
      this.txtOpenDuelingLastName.Location = new Point(385, 28);
      this.txtOpenDuelingLastName.Name = "txtOpenDuelingLastName";
      this.txtOpenDuelingLastName.Size = new Size(200, 20);
      this.txtOpenDuelingLastName.TabIndex = 3;
      this.txtOpenDuelingLastName.KeyDown += new KeyEventHandler(this.txtOpenDuelingLastName_KeyDown);
      this.txtOpenDuelingLastName.KeyUp += new KeyEventHandler(this.txtOpenDuelingLastName_KeyUp);
      this.txtOpenDuelingFirstname.Location = new Point(124, 28);
      this.txtOpenDuelingFirstname.Name = "txtOpenDuelingFirstname";
      this.txtOpenDuelingFirstname.Size = new Size(142, 20);
      this.txtOpenDuelingFirstname.TabIndex = 2;
      this.txtOpenDuelingFirstname.KeyDown += new KeyEventHandler(this.txtOpenDuelingFirstname_KeyDown);
      this.txtOpenDuelingFirstname.KeyUp += new KeyEventHandler(this.txtOpenDuelingFirstname_KeyUp);
      this.label9.AutoSize = true;
      this.label9.Location = new Point(294, 31);
      this.label9.Name = "label9";
      this.label9.Size = new Size(58, 13);
      this.label9.TabIndex = 1;
      this.label9.Text = "Last Name";
      this.label8.AutoSize = true;
      this.label8.Location = new Point(46, 31);
      this.label8.Name = "label8";
      this.label8.Size = new Size(57, 13);
      this.label8.TabIndex = 0;
      this.label8.Text = "First Name";
      this.panelStandings.Controls.Add((Control) this.ddlStandingsRound);
      this.panelStandings.Controls.Add((Control) this.label5);
      this.panelStandings.Controls.Add((Control) this.chkStandingsIncludeDroppedPlayers);
      this.panelStandings.Controls.Add((Control) this.dgStandings);
      this.panelStandings.Dock = DockStyle.Fill;
      this.panelStandings.Location = new Point(0, 0);
      this.panelStandings.Name = "panelStandings";
      this.panelStandings.Size = new Size(784, 564);
      this.panelStandings.TabIndex = 13;
      this.panelStandings.VisibleChanged += new EventHandler(this.panelStandings_VisibleChanged);
      this.printDocPlayerList.PrintPage += new PrintPageEventHandler(this.printDocPlayerList_PrintPage);
      this.printDocPairings.PrintPage += new PrintPageEventHandler(this.printDocPairings_PrintPage);
      this.printDocResultSlips.PrintPage += new PrintPageEventHandler(this.printDocResultSlips_PrintPage);
      this.printDocStandings.PrintPage += new PrintPageEventHandler(this.printDocStandings_PrintPage);
      this.printDocPlayerNotes.DocumentName = "Player Notes";
      this.printDocPlayerNotes.PrintPage += new PrintPageEventHandler(this.printDocPlayerNotes_PrintPage);
      this.subMenuEditGlobalPlayer.Items.AddRange(new ToolStripItem[5]
      {
        (ToolStripItem) this.subMenuGlobalPlayer_changePlayerNameToolStripMenuItem,
        (ToolStripItem) this.subMenuGlobalPlayer_changePlayerCOSSYIDToolStripMenuItem,
        (ToolStripItem) this.subMenuGlobalPlayer_deletePlayerToolStripMenuItem,
        (ToolStripItem) this.subMenuGlobalPlayer_viewMatchHistoryToolStripMenuItem,
        (ToolStripItem) this.subMenuGlobalPlayer_viewPLayersPenaltiesToolStripMenuItem
      });
      this.subMenuEditGlobalPlayer.Name = "subMenuEditGlobalPlayer";
      this.subMenuEditGlobalPlayer.ShowImageMargin = false;
      this.subMenuEditGlobalPlayer.Size = new Size(170, 114);
      this.subMenuGlobalPlayer_changePlayerNameToolStripMenuItem.Name = "subMenuGlobalPlayer_changePlayerNameToolStripMenuItem";
      this.subMenuGlobalPlayer_changePlayerNameToolStripMenuItem.Size = new Size(169, 22);
      this.subMenuGlobalPlayer_changePlayerNameToolStripMenuItem.Text = "Change Player Name";
      this.subMenuGlobalPlayer_changePlayerNameToolStripMenuItem.Click += new EventHandler(this.subMenuGlobalPlayer_changePlayerNameToolStripMenuItem_Click);
      this.subMenuGlobalPlayer_changePlayerCOSSYIDToolStripMenuItem.Name = "subMenuGlobalPlayer_changePlayerCOSSYIDToolStripMenuItem";
      this.subMenuGlobalPlayer_changePlayerCOSSYIDToolStripMenuItem.Size = new Size(169, 22);
      this.subMenuGlobalPlayer_changePlayerCOSSYIDToolStripMenuItem.Text = "Change Player COSSY ID";
      this.subMenuGlobalPlayer_changePlayerCOSSYIDToolStripMenuItem.Click += new EventHandler(this.subMenuGlobalPlayer_changePlayerCOSSYIDToolStripMenuItem_Click);
      this.subMenuGlobalPlayer_deletePlayerToolStripMenuItem.Name = "subMenuGlobalPlayer_deletePlayerToolStripMenuItem";
      this.subMenuGlobalPlayer_deletePlayerToolStripMenuItem.Size = new Size(169, 22);
      this.subMenuGlobalPlayer_deletePlayerToolStripMenuItem.Text = "Delete Player";
      this.subMenuGlobalPlayer_deletePlayerToolStripMenuItem.Click += new EventHandler(this.subMenuGlobalPlayer_deletePlayerToolStripMenuItem_Click);
      this.subMenuGlobalPlayer_viewMatchHistoryToolStripMenuItem.Name = "subMenuGlobalPlayer_viewMatchHistoryToolStripMenuItem";
      this.subMenuGlobalPlayer_viewMatchHistoryToolStripMenuItem.Size = new Size(169, 22);
      this.subMenuGlobalPlayer_viewMatchHistoryToolStripMenuItem.Text = "View Match History";
      this.subMenuGlobalPlayer_viewMatchHistoryToolStripMenuItem.Click += new EventHandler(this.subMenuGlobalPlayer_viewMatchHistoryToolStripMenuItem_Click);
      this.subMenuGlobalPlayer_viewPLayersPenaltiesToolStripMenuItem.Name = "subMenuGlobalPlayer_viewPLayersPenaltiesToolStripMenuItem";
      this.subMenuGlobalPlayer_viewPLayersPenaltiesToolStripMenuItem.Size = new Size(169, 22);
      this.subMenuGlobalPlayer_viewPLayersPenaltiesToolStripMenuItem.Text = "View Player's Penalties";
      this.subMenuGlobalPlayer_viewPLayersPenaltiesToolStripMenuItem.Click += new EventHandler(this.subMenuGlobalPlayer_viewPLayersPenaltiesToolStripMenuItem_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(784, 564);
      this.Controls.Add((Control) this.tabTournaments);
      this.Controls.Add((Control) this.mainToolStrip);
      this.Controls.Add((Control) this.mainMenuStrip);
      this.Controls.Add((Control) this.mainStatusStrip);
      this.Controls.Add((Control) this.panelPlayerEntry);
      this.Controls.Add((Control) this.panelStandings);
      this.Controls.Add((Control) this.panelResultsEntry);
      this.Controls.Add((Control) this.panelOpenDueling);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MainMenuStrip = this.mainMenuStrip;
      this.Name = nameof (MainForm);
      this.Text = "Konami Tournament Software";
      this.Load += new EventHandler(this.MainForm_Load);
      this.FormClosing += new FormClosingEventHandler(this.MainForm_FormClosing);
      this.Resize += new EventHandler(this.MainForm_Resize);
      this.mainStatusStrip.ResumeLayout(false);
      this.mainStatusStrip.PerformLayout();
      this.mainMenuStrip.ResumeLayout(false);
      this.mainMenuStrip.PerformLayout();
      ((ISupportInitialize) this.dgStandings).EndInit();
      this.mainToolStrip.ResumeLayout(false);
      this.mainToolStrip.PerformLayout();
      this.subMenuMatchResult.ResumeLayout(false);
      this.panelPlayerEntry.ResumeLayout(false);
      this.panelPlayerEntry.PerformLayout();
      this.panelResultsEntry.ResumeLayout(false);
      this.panelResultsEntry.PerformLayout();
      this.groupBoxMatchResults.ResumeLayout(false);
      this.groupBoxMatchResults.PerformLayout();
      ((ISupportInitialize) this.dgMatches).EndInit();
      this.panelOpenDueling.ResumeLayout(false);
      this.panelOpenDueling.PerformLayout();
      ((ISupportInitialize) this.dgOpenDueling).EndInit();
      this.panelStandings.ResumeLayout(false);
      this.panelStandings.PerformLayout();
      this.subMenuEditGlobalPlayer.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private bool _PlayerIdEntered
    {
      get
      {
        if (Engine.AllowTempID)
          return true;
        if (this.txtCurrentPlayerID.Text.Trim().Length != 10)
          return false;
        long result = 0;
        return long.TryParse(this.txtCurrentPlayerID.Text, out result);
      }
    }

    private ITournament ActiveTournament
    {
      get
      {
        if (!this.IsActiveTournament)
          return (ITournament) null;
        string name = this.tabTournaments.SelectedTab.Name;
        foreach (ITournament allTournament in (List<ITournament>) Engine.AllTournaments)
        {
          if (string.Compare(allTournament.ID, name, true) == 0)
            return allTournament;
        }
        return (ITournament) null;
      }
    }

    private string CurrentRowFilter
    {
      get
      {
        return this.chkHideCompletedMatches.Checked ? "IsNull(Result, '') = ''" : "";
      }
    }

    private ITournMatch CurrentTournMatch
    {
      get
      {
        if (!this.IsActiveTournament)
          return (ITournMatch) null;
        if (this.TableFromResultsEntry == -1)
          return (ITournMatch) null;
        return this.RoundFromDropDownList == -1 ? (ITournMatch) null : this.ActiveTournament.Matches.GetByRoundTable(this.RoundFromDropDownList, this.TableFromResultsEntry);
      }
    }

    private bool IsActiveTournament
    {
      get
      {
        return this.tabTournaments != null && this.tabTournaments.SelectedTab != null && string.Compare(this.tabTournaments.SelectedTab.Name, "0", true) != 0;
      }
    }

    private int RoundFromDropDownList
    {
      get
      {
        int result = -1;
        if (this.ddlResultsEntryRound.SelectedItem != null)
          int.TryParse(this.ddlResultsEntryRound.SelectedItem.ToString(), out result);
        else if (this.IsActiveTournament)
          result = this.ActiveTournament.CurrentRound;
        return result;
      }
    }

    private int TableFromResultsEntry
    {
      get
      {
        int result = -1;
        if (this.txtResultsEntryTable.Text.Trim().Length > 0)
        {
          int.TryParse(this.txtResultsEntryTable.Text, out result);
          if (this.IsActiveTournament)
            result -= this.ActiveTournament.TableOffset;
        }
        return result;
      }
    }

    private int ViewStandingsRound
    {
      get
      {
        int result = 0;
        if (this.ddlStandingsRound.Items.Count == 0)
          return result;
        int.TryParse(this.ddlStandingsRound.SelectedText, out result);
        if (result > 0)
          return result;
        if (this.ddlStandingsRound.SelectedItem != null)
          int.TryParse(this.ddlStandingsRound.SelectedItem.ToString(), out result);
        return result > 0 || !this.IsActiveTournament ? result : this.ActiveTournament.CurrentRound;
      }
    }

    private void _AddOpenDuelingPoint(IPlayer player, int points)
    {
      if (!this.IsActiveTournament)
        return;
      ITournPlayer byId = this.ActiveTournament.Players.FindById(player.ID);
      if (byId == null)
        return;
      byId.OpenDuelingPoints += points;
    }

    private IPlayerArray _AddPlayersAndStaff(ITournament tourn)
    {
      PlayerArray playerArray = new PlayerArray();
      playerArray.AddRange(Engine.PlayerList.Append(tourn.Players.Downgrade()));
      playerArray.Append(this._AddStaffToPlayerList(tourn));
      return (IPlayerArray) playerArray;
    }

    private IPlayerArray _AddStaffToPlayerList(ITournament tourn)
    {
      PlayerArray playerArray = new PlayerArray();
      if (tourn == null)
        return (IPlayerArray) playerArray;
      foreach (ITournStaff tournStaff in (IEnumerable<ITournStaff>) tourn.Staff)
      {
        if (!Engine.PlayerList.HasPlayer(tournStaff.ID) && !tournStaff.IsBye)
        {
          playerArray.AddPlayer((IPlayer) tournStaff);
          Engine.PlayerList.AddPlayer((IPlayer) tournStaff);
        }
      }
      if (playerArray.Count > 0)
        MainForm._SavePlayerList(true);
      return (IPlayerArray) playerArray;
    }

    private void _ChangePlayerID(long oldPlayerId, long newPlayerId)
    {
      IPlayer byId1 = Engine.PlayerList.FindById(oldPlayerId);
      if (byId1 == null)
        return;
      if (Engine.GetCossyIdType(newPlayerId) == Engine.CossyIdType.None)
      {
        int num1 = (int) MessageBox.Show("Invalid new COSSY ID");
      }
      else
      {
        foreach (ITournament allTournament in (List<ITournament>) Engine.AllTournaments)
        {
          if (allTournament.Players.HasPlayer(oldPlayerId) && allTournament.Players.HasPlayer(newPlayerId))
          {
            int num2 = (int) MessageBox.Show(string.Format("Tournament {0} has both players enrolled, aborting COSSY ID change", (object) allTournament.Name));
            return;
          }
        }
        IPlayer byId2 = Engine.PlayerList.FindById(newPlayerId);
        if (byId2 != null)
          this._DeletePlayer(byId2);
        Engine.PlayerList.ChangePlayerId(oldPlayerId, newPlayerId);
        this._ChangePlayerName(newPlayerId, byId1.FirstName, byId1.LastName);
        this._ClearPlayerTextBoxes();
        foreach (ITournament allTournament in (List<ITournament>) Engine.AllTournaments)
        {
          allTournament.ChangePlayerId(oldPlayerId, newPlayerId);
          Engine.SaveTournamentToFile(allTournament);
          if (this.IsActiveTournament && allTournament.ID == this.ActiveTournament.ID)
            this.ShowPanel(this._PanelsGetVisiblePanel());
        }
        this._ShowEnrolledPlayers();
      }
    }

    private int _ChangePlayerName(long playerId, string firstName, string lastName)
    {
      int num = 0;
      IPlayer player = Engine.PlayerList.FindById(playerId);
      if (player != null)
      {
        player.FirstName = firstName;
        player.LastName = lastName;
        num = this.UI_GlobalPlayerList_UpdateName(player);
      }
      else
        player = (IPlayer) new Player(firstName, lastName, playerId);
      Engine.PlayerList.AddPlayer(player);
      foreach (ITournament allTournament in (List<ITournament>) Engine.AllTournaments)
      {
        ITournPlayer byId1 = allTournament.Players.FindById(playerId);
        if (byId1 != null)
        {
          byId1.FirstName = firstName;
          byId1.LastName = lastName;
          Engine.SaveTournamentToFile(allTournament);
        }
        ITournStaff byId2 = allTournament.Staff.FindById(playerId);
        if (byId2 != null)
        {
          byId2.FirstName = firstName;
          byId2.LastName = lastName;
          Engine.SaveTournamentToFile(allTournament);
        }
      }
      MainForm._SavePlayerList(true);
      return num;
    }

    private void _ClearOpenDuelingPlayer()
    {
      this._ClearPlayerTextBoxes();
      this.txtOpenDuelingFirstname.Focus();
    }

    private void _ClearPlayerTextBoxes()
    {
      this.txtCurrentPlayerFirstName.Text = string.Empty;
      this.txtCurrentPlayerLastName.Text = string.Empty;
      this.txtCurrentPlayerID.Text = string.Empty;
      this.txtOpenDuelingFirstname.Text = string.Empty;
      this.txtOpenDuelingLastName.Text = string.Empty;
      Engine.CurrentPlayer = (IPlayer) null;
      this.txtCurrentPlayerID.Focus();
    }

    private void _DeletePlayer(IPlayer p)
    {
      Engine.PlayerList.DeletePlayer(Engine.PlayerList.FindById(p.ID));
      MainForm._SavePlayerList(true);
      this.UI_GlobalPlayerList_RemovePlayer(p);
      this._ClearPlayerTextBoxes();
    }

    private void _DropPlayer(ITournament tourn, long tournPlayerId, CutType dropReason)
    {
      if (tournPlayerId == Player.BYE_ID)
        return;
      ITournPlayer byId = tourn.Players.FindById(tournPlayerId);
      if (byId == null)
        return;
      byId.DropReason = dropReason;
      int num = tourn.CurrentRound;
      if (this.RoundFromDropDownList > 0)
        num = this.RoundFromDropDownList;
      if (dropReason != CutType.Active)
      {
        if (tourn.CurrentRound == 0)
          tourn.Players.RemovePlayer(byId);
        else
          byId.DropRound = num;
      }
      else
      {
        byId.DropRound = 0;
        tourn.AddMissingMatches(byId);
      }
      Engine.LogAction(tourn, UserAction.Drop_Player, (object) byId.FullNameWithId, (object) num, (object) dropReason);
      Engine.SaveTournamentToFile(tourn);
    }

    private IPlayer _EnrollGenericPlayer(
      TextBox txtFirstName,
      TextBox txtLastName,
      TextBox txtId)
    {
      if (Engine.CurrentPlayerSelected)
      {
        if (txtFirstName.Text.Length > 0 && txtLastName.Text.Length > 0)
        {
          Engine.CurrentPlayer.FirstName = txtFirstName.Text.Trim();
          Engine.CurrentPlayer.LastName = txtLastName.Text.Trim();
        }
      }
      else
      {
        long playerId = this.ParsePlayerId(txtId.Text);
        if (playerId == Player.BYE_ID)
          return (IPlayer) null;
        if (Engine.GetCossyIdType(playerId) == Engine.CossyIdType.None && MessageBox.Show(string.Format("{0}: Invalid COSSY ID, Continue?", (object) Utility.MakeDisplayCOSSY(playerId)), "Error", MessageBoxButtons.YesNo) == DialogResult.No)
          return (IPlayer) null;
        Engine.CurrentPlayer = (IPlayer) new Player(txtFirstName.Text.Trim(), txtLastName.Text.Trim(), playerId);
        Engine.PlayerList.AddPlayer(Engine.CurrentPlayer);
        this._ShowAdditionalPlayer(Engine.CurrentPlayer);
      }
      if (!this.IsActiveTournament)
        return Engine.CurrentPlayer;
      ITournament activeTournament = this.ActiveTournament;
      if (activeTournament.IsPlayoffs || activeTournament.Finalized || activeTournament.PairingStructure == TournamentPairingStructure.SingleElimination && activeTournament.CurrentRound > 0)
        return Engine.CurrentPlayer;
      if (activeTournament.Players.HasPlayer(Engine.CurrentPlayer.ID))
      {
        int num = (int) MessageBox.Show("Player is already registered for the tournament.");
        this._ShowEnrolledPlayers(Engine.CurrentPlayer.ID);
        this._ClearPlayerTextBoxes();
        return Engine.CurrentPlayer;
      }
      if (!activeTournament.EnrollPlayer(Engine.CurrentPlayer))
        return (IPlayer) null;
      Engine.LogAction(activeTournament, UserAction.Enroll_Player, (object) Engine.CurrentPlayer.FullNameWithId);
      IPlayer currentPlayer = Engine.CurrentPlayer;
      this._ShowEnrolledPlayers(Engine.CurrentPlayer.ID);
      this.UI_UpdateStatusBar();
      this.UI_UpdateToolbar();
      Engine.SaveTournamentToFile(activeTournament);
      this._ClearPlayerTextBoxes();
      txtId.Focus();
      return currentPlayer;
    }

    private IPlayer _EnrollOpenDuelingPlayer()
    {
      return this._EnrollGenericPlayer(this.txtOpenDuelingFirstname, this.txtOpenDuelingLastName, (TextBox) null);
    }

    private IPlayer _EnrollSelectedPlayer()
    {
      return this._EnrollGenericPlayer(this.txtCurrentPlayerFirstName, this.txtCurrentPlayerLastName, this.txtCurrentPlayerID);
    }

    private string[] _OpenMultipleTournaments()
    {
      this.dlgOpenFile.Multiselect = true;
      this.dlgOpenFile.RestoreDirectory = true;
      this.dlgOpenFile.DefaultExt = "Tournament";
      this.dlgOpenFile.Filter = "Tournament Xml Files (*.Tournament)|*.Tournament";
      if (Directory.Exists(Konami.Properties.Settings.Default.DataStorageFolder))
        this.dlgOpenFile.InitialDirectory = Konami.Properties.Settings.Default.DataStorageFolder;
      if (this.dlgOpenFile.ShowDialog() == DialogResult.OK)
      {
        this.dlgOpenFile.Multiselect = false;
        return this.dlgOpenFile.FileNames;
      }
      this.dlgOpenFile.Multiselect = false;
      return (string[]) null;
    }

    private Tournament _OpenTournament(string filename)
    {
      XmlDocument xmlDocument = new XmlDocument();
      XmlReader reader = XmlReader.Create((TextReader) new StreamReader(filename), this._xmlReaderSettings);
      xmlDocument.Load(reader);
      reader.Close();
      XmlNode xmlNode = xmlDocument.SelectSingleNode("/Tournament/SoftwareVersion");
      try
      {
        Version version1 = Assembly.GetExecutingAssembly().GetName().Version;
        Version version2 = new Version(xmlNode.InnerText);
        if (version1 < version2)
        {
          int num = (int) MessageBox.Show(string.Format("Tournament {0} was run on version {1} of KTS, and this is version {2}", (object) xmlDocument.SelectSingleNode("/Tournament/Name").InnerText, (object) version2, (object) version1));
          return (Tournament) null;
        }
      }
      catch (Exception ex)
      {
      }
      Tournament tournament = new Tournament();
      tournament.FromXml((XmlNode) xmlDocument.DocumentElement);
      if (Engine.LocationList.FindById(tournament.Location.Id) == null)
      {
        Engine.LocationList.Add(tournament.Location);
        this._SaveLocationList(true);
      }
      if (!this._tournamentBatchPrintings.ContainsKey(tournament.ID))
        this._tournamentBatchPrintings.Add(tournament.ID, new PrintBatchCounts());
      Engine.LogAction((ITournament) tournament, UserAction.Tourn_Open, (object) Path.GetFileNameWithoutExtension(filename));
      return tournament;
    }

    private ITournament _OpenTournamentDialog()
    {
      this.dlgOpenFile.RestoreDirectory = true;
      this.dlgOpenFile.DefaultExt = "Tournament";
      this.dlgOpenFile.Filter = "Tournament Xml Files (*.Tournament)|*.Tournament";
      if (Directory.Exists(Konami.Properties.Settings.Default.DataStorageFolder))
        this.dlgOpenFile.InitialDirectory = Konami.Properties.Settings.Default.DataStorageFolder;
      return this.dlgOpenFile.ShowDialog() == DialogResult.OK ? (ITournament) this._OpenTournament(this.dlgOpenFile.FileName) : (ITournament) null;
    }

    private void _PairNextRound(ITournament tourn, bool forceRepair)
    {
      if (tourn == null)
        return;
      ITournament tournament = tourn;
      if (tournament == null)
        return;
      if (tournament.ActivePlayers.Count < 2)
      {
        int num = (int) MessageBox.Show("Not enough players to pair the next round");
      }
      else if (tournament.Matches.UnreportedMatches.Count > 0 || forceRepair)
      {
        if (MessageBox.Show("Are you sure you want to repair this round?", "Caution", MessageBoxButtons.YesNo) != DialogResult.Yes)
          return;
        this.WaitCursor(true);
        Engine.SaveTournamentToFile(tournament);
        tournament.Matches.DeleteRound(tournament.CurrentRound);
        tournament.CurrentRound = Math.Max(0, tournament.CurrentRound - 1);
        tournament.PairNextRound();
        this.ShowPanel(MainForm.PanelTypes.Matches);
        Engine.SaveTournamentToFile(tournament);
        this.WaitCursor(false);
      }
      else
      {
        this.WaitCursor(true);
        Engine.SaveTournamentToFile(tournament);
        if (tournament.PairNextRound())
        {
          this.ShowPanel(MainForm.PanelTypes.Matches);
          Engine.SaveTournamentToFile(tournament);
        }
        this.WaitCursor(false);
      }
    }

    private MainForm.PanelTypes _PanelsGetLastPanel(ITournament tournament)
    {
      string key = "0";
      if (tournament != null)
        key = tournament.ID;
      if (this._tournamentLastViews.ContainsKey(key))
        return this._tournamentLastViews[key];
      MainForm.PanelTypes panel = MainForm.PanelTypes.EnrollPlayer;
      if (tournament != null && tournament.CurrentRound > 0)
        panel = MainForm.PanelTypes.Matches;
      this._PanelsSetPanel(tournament, panel);
      return panel;
    }

    private MainForm.PanelTypes _PanelsGetVisiblePanel()
    {
      if (this.panelResultsEntry.Visible)
        return MainForm.PanelTypes.Matches;
      if (this.panelOpenDueling.Visible)
        return MainForm.PanelTypes.OpenDueling;
      if (this.panelPlayerEntry.Visible)
        return MainForm.PanelTypes.EnrollPlayer;
      return this.panelStandings.Visible ? MainForm.PanelTypes.Standings : MainForm.PanelTypes.None;
    }

    private void _PanelsSetPanel(ITournament tournament, MainForm.PanelTypes panel)
    {
      string key = "0";
      if (tournament != null)
        key = tournament.ID;
      if (this._tournamentLastViews.ContainsKey(key))
        this._tournamentLastViews[key] = panel;
      else
        this._tournamentLastViews.Add(key, panel);
    }

    private void _PerformPlayerSearch()
    {
      if (this.txtAllPlayerSearch.Text.Length > 0)
        this._ShowGlobalPlayers(this.txtAllPlayerSearch.Text);
      else
        this._ShowGlobalPlayers();
    }

    private bool _PrintPairings(
      ITournament targetTournament,
      Engine.PrintPairingsAction currentPairingsPrint,
      int copies,
      string selectedPrinter)
    {
      if (targetTournament == null)
        return false;
      ITournament tourn = targetTournament;
      Engine.LogAction(tourn, UserAction.Print, (object) CommonEnumLists.PrintPairingsActionNames[this._currentPairingsPrint], (object) selectedPrinter, (object) copies, (object) " Copies");
      this._maxPrintCopy = copies;
      this._currentPairingsPrint = currentPairingsPrint;
      this._currentPrintPage = 0;
      this._currentPrintPairingsRow = 0;
      this._currentPrintCopy = 0;
      this._currentPrintSplitGroup = 0;
      ITournMatchArray tournMatchArray = (ITournMatchArray) null;
      switch (currentPairingsPrint)
      {
        case Engine.PrintPairingsAction.PrintByTable:
          tournMatchArray = tourn.Matches.GetByRound(this.RoundFromDropDownList);
          break;
        case Engine.PrintPairingsAction.PrintByPlayer:
          tournMatchArray = tourn.Matches.GetByRound(this.RoundFromDropDownList);
          break;
        case Engine.PrintPairingsAction.PrintUnreported:
          tournMatchArray = tourn.Matches.UnreportedMatches;
          break;
        case Engine.PrintPairingsAction.RandomMatches:
          this._maxPrintCopy = 1;
          ITournMatchArray byRound = tourn.Matches.GetByRound(this.RoundFromDropDownList);
          copies = Math.Max(Math.Min(copies, byRound.Count), 0);
          tournMatchArray = (ITournMatchArray) new TournMatchArray();
          while (tournMatchArray.Count < copies && tournMatchArray.Count < byRound.Count)
          {
            int table = Common.RandomGenerator.Next(1, byRound.Count + 1) + tourn.TableOffset;
            if (tournMatchArray.GetByRoundTable(this.RoundFromDropDownList, table) == null)
              tournMatchArray.AddMatch(byRound.GetByRoundTable(this.RoundFromDropDownList, table));
          }
          break;
        case Engine.PrintPairingsAction.PrintBrackets:
          tournMatchArray = tourn.Matches.GetByRound(this.RoundFromDropDownList);
          break;
        case Engine.PrintPairingsAction.PairedDownPlayers:
          this._maxPrintCopy = copies;
          tournMatchArray = this.GetPairedDownPlayers(tourn.CurrentRound);
          this._currentPairingsPrint = Engine.PrintPairingsAction.PrintByTable;
          break;
      }
      if (tournMatchArray == null || tournMatchArray.Count == 0)
        return false;
      this._printingMatches = tournMatchArray;
      this._printingPlayerList = (ITournPlayerArray) new TournPlayerArray();
      foreach (ITournPlayer player in (IEnumerable<ITournPlayer>) tourn.Players)
      {
        if (player.IsActive || player.DropRound >= this.RoundFromDropDownList)
          this._printingPlayerList.AddPlayer(player);
      }
      this._printingPlayerList.SortByLastname();
      this.printDocPairings.DocumentName = tournMatchArray[0].Round != 0 ? string.Format("{0}: {1} - Round {2}", (object) tourn.Name, (object) CommonEnumLists.PrintPairingsActionNames[currentPairingsPrint], (object) tournMatchArray[0].Round) : string.Format("{0}: Seat All Players", (object) tourn.Name);
      this.printDocPairings.PrinterSettings.PrinterName = selectedPrinter;
      this.printDocPairings.PrinterSettings.Copies = (short) 1;
      this.printDocPairings.Print();
      return true;
    }

    private void _PrintResultSlips(
      ITournament targetTournament,
      ITournMatchArray matches,
      string selectedPrinter)
    {
      this._currentPrintPage = 0;
      this._printingMatches = matches;
      this.printDocResultSlips.DocumentName = targetTournament != null ? targetTournament.Name + " Result Slips" : "Result Slips";
      this.printDocResultSlips.PrinterSettings.PrinterName = selectedPrinter;
      this.printDocResultSlips.Print();
    }

    private void _PrintStandings(
      ITournament targetTournament,
      int copies,
      string printerName,
      bool allplayers,
      bool allpages)
    {
      if (targetTournament == null)
        return;
      ITournament tourn = targetTournament;
      int num = !this.panelResultsEntry.Visible ? (!this.panelStandings.Visible ? (tourn.Matches.UnreportedMatches.Count != 0 ? Math.Max(0, tourn.CurrentRound - 1) : tourn.CurrentRound) : this.ViewStandingsRound) : (tourn.Matches.UnreportedMatches.Count != 0 ? Math.Max(0, this.RoundFromDropDownList - 1) : this.RoundFromDropDownList);
      tourn.CalculateTies(num);
      tourn.Players.AssignRanks(num, allplayers);
      Engine.LogAction(tourn, UserAction.Print_Standings, (object) tourn.TiebreakerRoundCalculated);
      this.printDocStandings.DocumentName = string.Format("{0} Standings after round {1}", (object) tourn.Name, (object) num);
      this.printDocStandings.PrinterSettings.Copies = (short) 1;
      this.printDocStandings.PrinterSettings.Collate = this.dlgPrintStandings.Collate;
      this.printDocStandings.PrinterSettings.PrinterName = printerName;
      if (allpages)
      {
        this.printDocStandings.PrinterSettings.PrintRange = PrintRange.AllPages;
      }
      else
      {
        this.printDocStandings.PrinterSettings.PrintRange = PrintRange.SomePages;
        this.printDocStandings.PrinterSettings.FromPage = this.dlgPrintStandings.PrintFrom;
        this.printDocStandings.PrinterSettings.ToPage = this.dlgPrintStandings.PrintTo;
      }
      this._currentPrintPage = 0;
      this._currentPrintCopy = 0;
      this._maxPrintCopy = copies;
      this._printingPlayerList = (ITournPlayerArray) new TournPlayerArray();
      if (allplayers)
      {
        this._printingPlayerList.Append(tourn.Players);
      }
      else
      {
        foreach (ITournPlayer player in (IEnumerable<ITournPlayer>) tourn.Players)
        {
          if (player.IsActive || player.DropRound >= this.RoundFromDropDownList)
            this._printingPlayerList.AddPlayer(player);
        }
      }
      this._printingPlayerList.SortByRank();
      this.printDocStandings.Print();
    }

    private bool _ProcessResultEntryCommand(char keyPress)
    {
      KeyEventArgs keyArgs = new KeyEventArgs(Keys.None);
      return this._ProcessResultEntryCommand(keyPress, keyArgs);
    }

    private bool _ProcessResultEntryCommand(char keyPress, KeyEventArgs keyArgs)
    {
      if (Engine.CurrentTournMatch == null || keyPress == '*' && Engine.CurrentTournMatch.Players.FindById(Player.BYE_ID) != null || !this.IsActiveTournament)
        return false;
      ITournament activeTournament = this.ActiveTournament;
      if (Engine.CurrentTournMatch.Completed && MessageBox.Show("Winner already recorded, overwrite existing result?", "Confirm Change", MessageBoxButtons.YesNo) != DialogResult.Yes)
      {
        this.radioResultsDoubleLoss.Checked = Engine.CurrentTournMatch.Status == TournMatchResult.DoubleLoss;
        this.radioResultsDraw.Checked = Engine.CurrentTournMatch.Status == TournMatchResult.Draw;
        this.radioResultsPlayer1.Checked = Engine.CurrentTournMatch.Winner == Engine.CurrentTournMatch.Players[0].ID;
        this.radioResultsPlayer2.Checked = Engine.CurrentTournMatch.Winner == Engine.CurrentTournMatch.Players[1].ID;
        this.radioResultsUnreported.Checked = Engine.CurrentTournMatch.Status == TournMatchResult.Incomplete;
        return false;
      }
      bool flag = true;
      switch (keyPress)
      {
        case '$':
          activeTournament.SubmitResult(Engine.CurrentTournMatch, TournMatchResult.Incomplete, Player.BYE_ID);
          break;
        case '*':
          if (Engine.CurrentTournMatch.Players.FindById(Player.BYE_ID) == null)
          {
            activeTournament.SubmitResult(Engine.CurrentTournMatch, TournMatchResult.Draw, Player.BYE_ID);
            break;
          }
          break;
        case '+':
        case '=':
          if (Engine.CurrentTournMatch.Players.Count < 2)
            return false;
          ITournPlayer player1 = Engine.CurrentTournMatch.Players[1];
          activeTournament.SubmitResult(Engine.CurrentTournMatch, TournMatchResult.Winner, player1.ID);
          if (keyArgs.Control && Engine.CurrentTournMatch.Players[0].IsActive)
          {
            this._DropPlayer(activeTournament, Engine.CurrentTournMatch.Players[0].ID, CutType.Drop);
            break;
          }
          break;
        case '-':
          ITournPlayer player2 = Engine.CurrentTournMatch.Players[0];
          activeTournament.SubmitResult(Engine.CurrentTournMatch, TournMatchResult.Winner, player2.ID);
          if (keyArgs.Control && Engine.CurrentTournMatch.Players.Count > 1 && Engine.CurrentTournMatch.Players[1].IsActive)
          {
            this._DropPlayer(activeTournament, Engine.CurrentTournMatch.Players[1].ID, CutType.Drop);
            break;
          }
          break;
        case '/':
          activeTournament.SubmitResult(Engine.CurrentTournMatch, TournMatchResult.DoubleLoss, Player.BYE_ID);
          if (keyArgs.Control)
          {
            using (IEnumerator<ITournPlayer> enumerator = Engine.CurrentTournMatch.Players.GetEnumerator())
            {
              while (enumerator.MoveNext())
              {
                ITournPlayer current = enumerator.Current;
                if (current.IsActive)
                  this._DropPlayer(activeTournament, current.ID, CutType.Drop);
              }
              break;
            }
          }
          else
            break;
        default:
          flag = false;
          break;
      }
      this._UpdateAfterMatchResult();
      if (flag)
        this.txtResultsEntryTable.SelectAll();
      return true;
    }

    private void _RefreshPairingsGrid(int Round)
    {
      if (!this.IsActiveTournament)
        return;
      ITournament activeTournament = this.ActiveTournament;
      ITournMatchArray byRound = activeTournament.Matches.GetByRound(Round, false);
      string index = string.Empty;
      ListSortDirection direction = ListSortDirection.Ascending;
      if (this.dgMatches.DataSource != null && this.dgMatches.SortedColumn != null)
      {
        index = this.dgMatches.SortedColumn.Name;
        direction = this.dgMatches.SortOrder == SortOrder.Descending ? ListSortDirection.Descending : ListSortDirection.Ascending;
      }
      this.dgMatches.ClearSelection();
      this.dgMatches.DataSource = (object) new DataView(TournMatchArray.GetDataTable(byRound, this.chkViewByPlayer.Checked, activeTournament.TableOffset, activeTournament.Players))
      {
        RowFilter = this.CurrentRowFilter
      };
      this.dgMatches.Columns["MatchObject"].Visible = false;
      this.dgMatches.Columns["Table"].Width = 50;
      this.dgMatches.Columns["Table"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
      this.dgMatches.Columns["Player 1 Object"].Visible = false;
      this.dgMatches.Columns["Player 1 Object"].FillWeight = 100f;
      this.dgMatches.Columns["Player 2 Object"].Visible = false;
      this.dgMatches.Columns["Player 2 Object"].FillWeight = 100f;
      this.dgMatches.Columns["Result"].FillWeight = 100f;
      this.dgMatches.ClearSelection();
      if (index != string.Empty)
      {
        DataGridViewColumn column = this.dgMatches.Columns[index];
        if (column == null)
          return;
        this.dgMatches.Sort(column, direction);
      }
      else if (this.chkViewByPlayer.Checked)
        this.dgMatches.Sort(this.dgMatches.Columns["Player 1"], ListSortDirection.Ascending);
      else
        this.dgMatches.Sort(this.dgMatches.Columns["Table"], ListSortDirection.Ascending);
    }

    private void _SaveLocationList(bool overwrite)
    {
      if (File.Exists(Engine.LocationListFilename) && !overwrite && MessageBox.Show("Overwrite existing file?", "Save Location List", MessageBoxButtons.YesNo) != DialogResult.Yes)
        return;
      this.WaitCursor(true);
      XmlWriter writer = XmlWriter.Create(Engine.LocationListFilename, this._xmlWriterSettings);
      Engine.LocationList.ToFullXml(writer);
      writer.Flush();
      writer.Close();
      this.WaitCursor(false);
    }

    private static void _SavePlayerList()
    {
      MainForm._SavePlayerList(false);
    }

    private static void _SavePlayerList(bool overwrite)
    {
      PlayerArray.WriteToFile(Engine.PlayerList, Engine.PlayerListFilename, overwrite);
    }

    private void _ShowAdditionalPlayer(IPlayer player)
    {
      if (player == null)
        return;
      IPlayer player1 = Engine.PlayerList.FindById(player.ID);
      if (player1 == null)
      {
        Engine.PlayerList.AddPlayer(player);
        player1 = player;
      }
      if (this.listNameLookup.Items.Contains((object) player1))
        return;
      this.WaitCursor(true);
      this.listNameLookup.BeginUpdate();
      this.listNameLookup.Items.Add((object) player1);
      this.listNameLookup.EndUpdate();
      this.UpdateGlobalPlayerCount();
      this.WaitCursor(false);
    }

    private void _ShowAdditionalPlayers(IPlayerArray players)
    {
      if (players.Count == 0)
        return;
      this.WaitCursor(true);
      IPlayer[] array = new IPlayer[players.Count];
      players.CopyTo(array, 0);
      this.listNameLookup.BeginUpdate();
      this.listNameLookup.Items.AddRange((object[]) array);
      this.listNameLookup.EndUpdate();
      this.UpdateGlobalPlayerCount();
      this.WaitCursor(false);
    }

    private void _ShowCurrentPlayer()
    {
      if (!Engine.CurrentPlayerSelected)
        return;
      IPlayer byId = Engine.PlayerList.FindById(Engine.CurrentPlayer.ID);
      this.txtCurrentPlayerFirstName.Text = byId.FirstName;
      this.txtCurrentPlayerLastName.Text = byId.LastName;
      this.txtCurrentPlayerID.Text = byId.IDFormatted;
      this.txtOpenDuelingFirstname.Text = byId.FirstName;
      this.txtOpenDuelingLastName.Text = byId.LastName;
    }

    private void _ShowEnrolledPlayers()
    {
      this._ShowEnrolledPlayers(Player.BYE_ID);
    }

    private void _ShowEnrolledPlayers(long selectedPlayerId)
    {
      if (!this.IsActiveTournament)
        return;
      ITournament activeTournament = this.ActiveTournament;
      activeTournament.Players.SortByLastname();
      this._ClearPlayerTextBoxes();
      this.listEnrolledPlayers.ClearSelected();
      this.listEnrolledPlayers.Items.Clear();
      if (activeTournament == null)
        return;
      this.WaitCursor(true);
      this.listEnrolledPlayers.BeginUpdate();
      if (activeTournament.Players.Count > 0)
      {
        ITournPlayer[] array = new ITournPlayer[activeTournament.Players.Count];
        activeTournament.Players.CopyTo(array, 0);
        this.listEnrolledPlayers.Items.AddRange((object[]) array);
      }
      this.listEnrolledPlayers.EndUpdate();
      if (selectedPlayerId != Player.BYE_ID)
      {
        for (int index = 0; index < this.listEnrolledPlayers.Items.Count; ++index)
        {
          if (((IPlayer) this.listEnrolledPlayers.Items[index]).ID == selectedPlayerId)
          {
            this.listEnrolledPlayers.TopIndex = index;
            this.listEnrolledPlayers.SelectedIndex = index;
            break;
          }
        }
      }
      this.WaitCursor(false);
    }

    private void _ShowGlobalPlayers()
    {
      this._ShowGlobalPlayers(false);
    }

    private void _ShowGlobalPlayers(bool forceReload)
    {
      if (!this.showingFilteredGlobalPlayers && this.listNameLookup.Items.Count != 0 && !forceReload)
        return;
      this.showingFilteredGlobalPlayers = false;
      this.WaitCursor(true);
      this.listNameLookup.Items.Clear();
      this.WaitCursor(false);
      if (Engine.PlayerList.Count == 0)
        return;
      this._ShowAdditionalPlayers(Engine.PlayerList);
    }

    private void _ShowGlobalPlayers(string searchKey)
    {
      if (string.IsNullOrEmpty(searchKey.Trim()))
      {
        this._ShowGlobalPlayers();
      }
      else
      {
        string lower = searchKey.Trim().ToLower();
        if (lower.Length < 3)
          return;
        this.WaitCursor(true);
        this.listNameLookup.Items.Clear();
        PlayerArray playerArray = new PlayerArray();
        foreach (IPlayer player in (IEnumerable<IPlayer>) Engine.PlayerList)
        {
          if (player.FirstName.IndexOf(lower, StringComparison.CurrentCultureIgnoreCase) >= 0 || player.LastName.IndexOf(lower, StringComparison.CurrentCultureIgnoreCase) >= 0)
            playerArray.AddPlayer(player);
        }
        this.WaitCursor(false);
        if (playerArray.Count == 0)
        {
          int num = (int) MessageBox.Show("No players found");
        }
        else
          this._ShowAdditionalPlayers((IPlayerArray) playerArray);
        this.showingFilteredGlobalPlayers = true;
      }
    }

    private void _ShowPairings(int Round)
    {
      if (!this.IsActiveTournament)
        return;
      this.UI_UpdateResultsEntry();
      this._RefreshPairingsGrid(Round);
    }

    private void _ShowPreferencesDialog()
    {
      bool idsDisplayOnScreen = Konami.Properties.Settings.Default.ShowPlayerIds_DisplayOnScreen;
      Engine.LogAction((ITournament) null, UserAction.Program_Options);
      if (new PreferencesDialog().ShowDialog() != DialogResult.OK)
        return;
      this.CopySettings();
      this.UI_UpdateToolbar();
      if (idsDisplayOnScreen == Konami.Properties.Settings.Default.ShowPlayerIds_DisplayOnScreen)
        return;
      this._ShowEnrolledPlayers();
      this._ShowGlobalPlayers(true);
    }

    private void _ShowStandings(ITournament tournament)
    {
      if (tournament == null)
        return;
      int round = tournament.CurrentRound;
      if (this.panelStandings.Visible)
        round = this.ViewStandingsRound;
      this._ShowStandings(tournament, round);
    }

    private void _ShowStandings(ITournament tournament, int round)
    {
      if (tournament == null)
        return;
      ITournament tournament1 = tournament;
      this.WaitCursor(true);
      tournament1.CalculateTies();
      bool flag = false;
      string index = string.Empty;
      ListSortDirection direction = ListSortDirection.Ascending;
      ITournPlayer tournPlayer = (ITournPlayer) null;
      if (tournament1.PairingStructure == TournamentPairingStructure.OpenDueling)
      {
        if (this.dgOpenDueling.DataSource != null && this.dgOpenDueling.SortedColumn != null)
        {
          flag = true;
          index = this.dgOpenDueling.SortedColumn.Name;
          direction = this.dgOpenDueling.SortOrder == SortOrder.Ascending ? ListSortDirection.Ascending : ListSortDirection.Descending;
        }
        if (this.dgOpenDueling.SelectedRows.Count > 0)
          tournPlayer = (ITournPlayer) this.dgOpenDueling.SelectedRows[0].Cells["TournPlayer"].Value;
        this.dgOpenDueling.DataSource = (object) tournament1.Players.GetOpenDuelingPoints();
        this.dgOpenDueling.Columns["TournPlayer"].Visible = false;
        if (flag && index != string.Empty)
        {
          DataGridViewColumn column = this.dgOpenDueling.Columns[index];
          if (column != null)
            this.dgOpenDueling.Sort(column, direction);
        }
        if (tournPlayer != null)
          this.OpenDuelingHighlightPlayer((IPlayer) tournPlayer);
      }
      else
      {
        if (this.dgStandings.DataSource != null && this.dgStandings.SortedColumn != null)
        {
          flag = true;
          index = this.dgStandings.SortedColumn.Name;
          direction = this.dgStandings.SortOrder == SortOrder.Ascending ? ListSortDirection.Ascending : ListSortDirection.Descending;
        }
        this.dgStandings.DataSource = (object) tournament1.GetStandings(round, this.chkStandingsIncludeDroppedPlayers.Checked);
        this.dgStandings.Columns["Player"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        if (flag && index != string.Empty)
        {
          DataGridViewColumn column = this.dgStandings.Columns[index];
          if (column != null)
            this.dgStandings.Sort(column, direction);
        }
        else
          this.dgStandings.Sort(this.dgStandings.Columns["Rank"], ListSortDirection.Ascending);
      }
      this.WaitCursor(false);
    }

    private void _ToggleShowCompletedMatches()
    {
      if (this.dgMatches.DataSource == null || !this.IsActiveTournament)
        return;
      DataView dataSource = (DataView) this.dgMatches.DataSource;
      if (dataSource == null)
        return;
      dataSource.RowFilter = this.CurrentRowFilter;
    }

    private void _UpdateAfterMatchResult()
    {
      if (!this.IsActiveTournament)
        return;
      this.WaitCursor(true);
      this.UI_UpdateResultsEntry();
      this.UI_UpdateStatusBar();
      ITournament activeTournament = this.ActiveTournament;
      if (activeTournament.Matches.UnreportedMatches.Count == 0)
        this._ShowStandings(activeTournament);
      Engine.SaveTournamentToFile(activeTournament);
      this.WaitCursor(false);
    }

    private void _UpdateRoundDropDownList()
    {
      if (!this.IsActiveTournament)
        return;
      this.ddlResultsEntryRound.Items.Clear();
      for (int currentRound = this.ActiveTournament.CurrentRound; currentRound > 0; --currentRound)
        this.ddlResultsEntryRound.Items.Add((object) currentRound.ToString());
      if (this.ddlResultsEntryRound.Items.Count <= 0)
        return;
      this.ddlResultsEntryRound.SelectedIndex = 0;
    }

    private void UI_AddPlayersToGlobalList()
    {
      this.dlgOpenFile.RestoreDirectory = true;
      this.dlgOpenFile.Filter = "CSV Files (*.csv)|*.csv|Tournament Files (*.tournament)|*.tournament|AllPlayers File (*.xml)|*.XML|All Files (*.*)|*.*";
      this.dlgOpenFile.DefaultExt = "csv";
      bool multiselect = this.dlgOpenFile.Multiselect;
      this.dlgOpenFile.Multiselect = true;
      if (Directory.Exists(Konami.Properties.Settings.Default.DataStorageFolder))
        this.dlgOpenFile.InitialDirectory = Konami.Properties.Settings.Default.DataStorageFolder;
      if (this.dlgOpenFile.ShowDialog() == DialogResult.OK)
      {
        this.WaitCursor(true);
        Engine.LogAction((ITournament) null, UserAction.Import_Player_List);
        PlayerArray playerArray = new PlayerArray();
        foreach (string fileName in this.dlgOpenFile.FileNames)
        {
          if (Path.GetExtension(fileName).ToLower() == ".csv")
          {
            try
            {
              playerArray.AddRange((IPlayerArray) Engine.AddPlayerCsvToAllPlayers(fileName));
            }
            catch (Exception ex)
            {
              int num = (int) MessageBox.Show(string.Format("Unrecognized file: {0}", (object) fileName));
            }
          }
          else if (Path.GetExtension(fileName).ToLower() == ".tournament")
          {
            Tournament tournament = this._OpenTournament(fileName);
            if (tournament != null)
              playerArray.Append(Engine.PlayerList.Append(tournament.Players.Downgrade()));
          }
          else if (string.Compare(Path.GetExtension(fileName), Path.GetExtension("AllPlayers.XML"), true) == 0)
          {
            try
            {
              playerArray.Append(Engine.PlayerList.Append(PlayerArray.LoadFromFile(fileName)));
            }
            catch (Exception ex)
            {
              int num = (int) MessageBox.Show(string.Format("Unrecognized file: {0}", (object) fileName));
            }
          }
          else
          {
            int num1 = (int) MessageBox.Show(string.Format("Unrecognized file: {0}", (object) fileName));
          }
        }
        PlayerArray.WriteToFile(Engine.PlayerList, Engine.PlayerListFilename, true);
        this.WaitCursor(false);
        int num2 = (int) MessageBox.Show(string.Format("{0} Players added", (object) playerArray.Count));
        this._ShowAdditionalPlayers((IPlayerArray) playerArray);
      }
      this.dlgOpenFile.Multiselect = multiselect;
    }

    private void UI_BatchPrinting()
    {
      if (!this.IsActiveTournament)
        return;
      ITournament activeTournament = this.ActiveTournament;
      DialogBatchPrinting dialogBatchPrinting = new DialogBatchPrinting();
      dialogBatchPrinting.TournamentName = activeTournament.Name;
      if (!this._tournamentBatchPrintings.ContainsKey(activeTournament.ID))
        this._tournamentBatchPrintings.Add(activeTournament.ID, new PrintBatchCounts());
      dialogBatchPrinting.BatchCounts = this._tournamentBatchPrintings[activeTournament.ID];
      int num = (int) dialogBatchPrinting.ShowDialog();
      if (!dialogBatchPrinting.Print)
        return;
      DialogPrinterSelect dialogPrinterSelect = new DialogPrinterSelect();
      dialogPrinterSelect.SelectedPrinter = this.printDocStandings.PrinterSettings.PrinterName;
      if (dialogPrinterSelect.ShowDialog() != DialogResult.OK)
        return;
      string selectedPrinter = dialogPrinterSelect.SelectedPrinter;
      foreach (Engine.PrintPairingsAction printPairingsAction in (Engine.PrintPairingsAction[]) Enum.GetValues(typeof (Engine.PrintPairingsAction)))
      {
        if (dialogBatchPrinting.BatchCounts.BatchCounts.ContainsKey(printPairingsAction))
        {
          int count = dialogBatchPrinting.BatchCounts.GetCount(printPairingsAction);
          if (count > 0)
          {
            switch (printPairingsAction)
            {
              case Engine.PrintPairingsAction.PrintByTable:
                this._PrintPairings(activeTournament, printPairingsAction, count, selectedPrinter);
                continue;
              case Engine.PrintPairingsAction.PrintByPlayer:
                this._PrintPairings(activeTournament, printPairingsAction, count, selectedPrinter);
                continue;
              case Engine.PrintPairingsAction.PrintUnreported:
                this._PrintPairings(activeTournament, printPairingsAction, count, selectedPrinter);
                continue;
              case Engine.PrintPairingsAction.RandomMatches:
                this._PrintPairings(activeTournament, printPairingsAction, count, selectedPrinter);
                continue;
              case Engine.PrintPairingsAction.PrintBrackets:
                this._PrintPairings(activeTournament, printPairingsAction, count, selectedPrinter);
                continue;
              case Engine.PrintPairingsAction.StandingsAllPlayers:
                this.dlgPrintStandings.IncludeTiebreakers = true;
                this._PrintStandings(activeTournament, count, selectedPrinter, true, true);
                continue;
              case Engine.PrintPairingsAction.StandingsAllPlayersNoTies:
                this.dlgPrintStandings.IncludeTiebreakers = false;
                this._PrintStandings(activeTournament, count, selectedPrinter, true, true);
                continue;
              case Engine.PrintPairingsAction.StandingsActivePlayers:
                this.dlgPrintStandings.IncludeTiebreakers = true;
                this._PrintStandings(activeTournament, count, selectedPrinter, false, true);
                continue;
              case Engine.PrintPairingsAction.StandingsActivePlayersNoTies:
                this.dlgPrintStandings.IncludeTiebreakers = false;
                this._PrintStandings(activeTournament, count, selectedPrinter, false, true);
                continue;
              case Engine.PrintPairingsAction.ResultSlips:
                ITournMatchArray byRound = activeTournament.Matches.GetByRound(this.RoundFromDropDownList);
                ITournMatchArray matches = (ITournMatchArray) new TournMatchArray();
                foreach (ITournMatch match in (IEnumerable<ITournMatch>) byRound)
                {
                  if (match.Players.FindById(Player.BYE_ID) == null)
                    matches.AddMatch(match);
                }
                this._PrintResultSlips(activeTournament, matches, selectedPrinter);
                continue;
              default:
                continue;
            }
          }
        }
      }
    }

    private void UI_CancelRound()
    {
      if (!this.IsActiveTournament || MessageBox.Show("Are you sure you want to cancel this round?", "Caution", MessageBoxButtons.YesNo) != DialogResult.Yes)
        return;
      this.WaitCursor(true);
      ITournament activeTournament = this.ActiveTournament;
      Engine.SaveTournamentToFile(activeTournament);
      activeTournament.Matches.DeleteRound(activeTournament.CurrentRound);
      if (activeTournament.PlayoffRound == activeTournament.CurrentRound)
        activeTournament.PlayoffRound = 0;
      activeTournament.CurrentRound = Math.Max(0, activeTournament.CurrentRound - 1);
      foreach (ITournPlayer player in (IEnumerable<ITournPlayer>) activeTournament.Players)
      {
        if (player.DropRound >= activeTournament.CurrentRound && (player.DropReason == CutType.PlayoffCut || player.DropReason == CutType.TopX || player.DropReason == CutType.Cut))
        {
          player.DropRound = 0;
          player.DropReason = CutType.Active;
        }
      }
      this.ShowPanel(MainForm.PanelTypes.Matches);
      Engine.SaveTournamentToFile(activeTournament);
      this.WaitCursor(false);
    }

    private void UI_Cleanup()
    {
      if (!this.IsActiveTournament)
        this.Text = "Konami Tournament Software - No Tournament Open";
      else
        this.Text = string.Format("Konami Tournament Software - {0}", (object) this.tabTournaments.SelectedTab.Text);
      this.UI_UpdateStatusBar();
      this._ShowEnrolledPlayers();
    }

    private void UI_CreateTempCossyID()
    {
      long num = 9999000000;
      while (Engine.PlayerList.FindById(num) != null)
        ++num;
      DialogNewPerson dialogNewPerson = new DialogNewPerson();
      dialogNewPerson.PlayerId = Utility.MakeDisplayCOSSY(num);
      if (dialogNewPerson.ShowDialog() != DialogResult.OK)
        return;
      Engine.CurrentPlayer = dialogNewPerson.NewPlayer;
      Engine.PlayerList.AddPlayer(Engine.CurrentPlayer);
      this._EnrollSelectedPlayer();
      this._ShowAdditionalPlayer(Engine.CurrentPlayer);
    }

    private void UI_ExportGlobalListToCSV()
    {
      this.dlgSaveFile.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
      this.dlgSaveFile.OverwritePrompt = true;
      this.dlgSaveFile.DefaultExt = "csv";
      this.dlgSaveFile.FileName = "AllPlayers.csv";
      if (Directory.Exists(Konami.Properties.Settings.Default.DataStorageFolder))
        this.dlgSaveFile.InitialDirectory = Konami.Properties.Settings.Default.DataStorageFolder;
      if (this.dlgSaveFile.ShowDialog() != DialogResult.OK)
        return;
      this.WaitCursor(true);
      string fileName = this.dlgSaveFile.FileName;
      Engine.PlayerList.SortByID();
      IPlayerArray playerList = Engine.PlayerList;
      PlayerArray.WriterPlayersToCsv(fileName, playerList);
      this.WaitCursor(false);
      int num = (int) MessageBox.Show("File created");
    }

    private void UI_ExportTournamentToCSV()
    {
      if (!this.IsActiveTournament)
        return;
      ITournament activeTournament = this.ActiveTournament;
      this.dlgSaveFile.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
      this.dlgSaveFile.OverwritePrompt = true;
      this.dlgSaveFile.DefaultExt = "csv";
      this.dlgSaveFile.FileName = activeTournament.Name + " - Matches";
      if (Directory.Exists(Konami.Properties.Settings.Default.DataStorageFolder))
        this.dlgSaveFile.InitialDirectory = Konami.Properties.Settings.Default.DataStorageFolder;
      if (this.dlgSaveFile.ShowDialog() != DialogResult.OK)
        return;
      activeTournament.ExportMatchesToCSV(this.dlgSaveFile.FileName);
    }

    private void UI_FinalizeTournament()
    {
      if (!this.IsActiveTournament)
        return;
      ITournament activeTournament = this.ActiveTournament;
      if (activeTournament.Matches.UnreportedMatches.Count > 0)
      {
        int num1 = (int) MessageBox.Show("Unable to finalize a tournament with unreported matches.");
      }
      else if (activeTournament.Players.TempPlayerCount > 0)
      {
        int num2 = (int) MessageBox.Show("Unable to finalize a tournament with temporary COSSY IDs.");
      }
      else if (activeTournament.Finalized)
      {
        int num3 = (int) MessageBox.Show("Tournament already finalized.");
      }
      else
      {
        if (MessageBox.Show("Finalize tournament?", "Finalize", MessageBoxButtons.YesNo) != DialogResult.Yes)
          return;
        activeTournament.Finalized = true;
        Engine.SaveTournamentToFinalizedFolder(activeTournament);
        this.UI_UpdateStatusBar();
      }
    }

    private void UI_GlobalPlayerList_RemovePlayer(IPlayer p)
    {
      if (this.listNameLookup.Items.IndexOf((object) p) < 0)
        return;
      this.listNameLookup.Items.RemoveAt(this.listNameLookup.Items.IndexOf((object) p));
    }

    private int UI_GlobalPlayerList_UpdateName(IPlayer player)
    {
      for (int index = 0; index < this.listNameLookup.Items.Count; ++index)
      {
        if (((IPlayer) this.listNameLookup.Items[index]).ID == player.ID)
          this.listNameLookup.Items.RemoveAt(index);
      }
      string fullName = player.FullName;
      for (int index = 0; index < this.listNameLookup.Items.Count; ++index)
      {
        IPlayer player1 = (IPlayer) this.listNameLookup.Items[index];
        if (fullName.CompareTo(player1.FullName) < 0)
        {
          this.listNameLookup.Items.Insert(index, (object) player);
          return index;
        }
      }
      if (this.listNameLookup.Items.IndexOf((object) player) >= 0)
        return 0;
      this.listNameLookup.Items.Insert(this.listNameLookup.Items.Count, (object) player);
      return this.listNameLookup.Items.Count - 1;
    }

    private void UI_MatchResultsTableHightlight()
    {
      this.txtResultsEntryTable.Focus();
      this.txtResultsEntryTable.SelectAll();
    }

    private bool UI_SaveTournamentDialog()
    {
      if (!this.IsActiveTournament)
        return false;
      ITournament activeTournament = this.ActiveTournament;
      this.dlgSaveFile.OverwritePrompt = true;
      this.dlgSaveFile.DefaultExt = "Tournament";
      this.dlgSaveFile.Filter = "Tournament Xml Files (*.Tournament)|*.Tournament";
      if (!Directory.Exists(Konami.Properties.Settings.Default.DataStorageFolder))
      {
        try
        {
          Directory.CreateDirectory(Konami.Properties.Settings.Default.DataStorageFolder);
        }
        catch (Exception ex)
        {
        }
      }
      if (Directory.Exists(Konami.Properties.Settings.Default.DataStorageFolder))
        this.dlgSaveFile.InitialDirectory = Konami.Properties.Settings.Default.DataStorageFolder;
      this.dlgSaveFile.FileName = activeTournament.Filename;
      if (this.dlgSaveFile.ShowDialog() != DialogResult.OK)
        return false;
      Engine.LogAction(activeTournament, UserAction.Tourn_Save);
      Engine.SaveTournamentToFile(activeTournament, this.dlgSaveFile.FileName);
      return true;
    }

    private void UI_UpdateAllMatchRowResult()
    {
      DataView dataSource = (DataView) this.dgMatches.DataSource;
      if (dataSource == null)
        return;
      foreach (DataRow row in (InternalDataCollectionBase) dataSource.Table.Rows)
      {
        ITournMatch tournMatch = (ITournMatch) row["MatchObject"];
        row["Result"] = (object) tournMatch.StatusText;
        ITournPlayer tournPlayer1 = (ITournPlayer) row["Player 1 Object"];
        row["Player 1"] = (object) tournPlayer1.ToString();
        ITournPlayer tournPlayer2 = (ITournPlayer) row["Player 2 Object"];
        row["Player 2"] = (object) tournPlayer2.ToString();
      }
    }

    private void UI_UpdateMatchRowPlayer(ITournPlayer player)
    {
      this.WaitCursor(true);
      DataView dataSource = (DataView) this.dgMatches.DataSource;
      if (dataSource != null)
      {
        foreach (DataRow row in (InternalDataCollectionBase) dataSource.Table.Rows)
        {
          if (row["MatchObject"] != null)
          {
            if (((IPlayer) row["Player 1 Object"]).ID == player.ID)
              row["Player 1"] = (object) player.ToString();
            if (((IPlayer) row["Player 2 Object"]).ID == player.ID)
              row["Player 2"] = (object) player.ToString();
            this.UI_UpdateMatchRowResult((ITournMatch) row["MatchObject"]);
          }
        }
      }
      this.WaitCursor(false);
    }

    private void UI_UpdateMatchRowResult(ITournMatch match)
    {
      this.WaitCursor(true);
      DataView dataSource = (DataView) this.dgMatches.DataSource;
      if (dataSource != null)
      {
        foreach (DataRow row in (InternalDataCollectionBase) dataSource.Table.Rows)
        {
          if (row["MatchObject"] != null)
          {
            ITournMatch tournMatch = (ITournMatch) row["MatchObject"];
            if (match.Table == tournMatch.Table)
            {
              row["Result"] = (object) match.StatusText;
              ITournPlayer tournPlayer1 = (ITournPlayer) row["Player 1 Object"];
              row["Player 1"] = (object) tournPlayer1.ToString();
              ITournPlayer tournPlayer2 = (ITournPlayer) row["Player 2 Object"];
              row["Player 2"] = (object) tournPlayer2.ToString();
            }
          }
        }
      }
      this.WaitCursor(false);
    }

    private void UI_UpdateResultsEntry()
    {
      if (!this.IsActiveTournament)
      {
        this.groupBoxMatchResults.Visible = false;
      }
      else
      {
        Engine.CurrentTournMatch = this.ActiveTournament.Matches.GetByRoundTable(this.RoundFromDropDownList, this.TableFromResultsEntry);
        if (Engine.CurrentTournMatch != null)
        {
          this.groupBoxMatchResults.Visible = true;
          if (Engine.CurrentTournMatch.Players.Count > 0)
          {
            string fullName = Engine.CurrentTournMatch.Players[0].FullName;
            this.radioResultsPlayer1.Text = string.Format("{0} Wins ( - )", (object) fullName);
            this.chkResultsPlayer1Drops.Text = string.Format("{0} Drops", (object) fullName);
            this.subMenuMatchResult.Items["insertPlayer1NameWinsToolStripMenuItem"].Text = fullName;
          }
          if (Engine.CurrentTournMatch.Players.Count > 1)
          {
            string fullName = Engine.CurrentTournMatch.Players[1].FullName;
            this.radioResultsPlayer2.Text = string.Format("{0} Wins ( + )", (object) fullName);
            this.chkResultsPlayer2Drops.Text = string.Format("{0} Drops", (object) fullName);
            this.subMenuMatchResult.Items["insertPlayer2NameWinsToolStripMenuItem"].Text = fullName;
          }
          this.radioResultsDoubleLoss.Checked = Engine.CurrentTournMatch.Status == TournMatchResult.DoubleLoss;
          this.radioResultsPlayer1.Checked = Engine.CurrentTournMatch.Winner == Engine.CurrentTournMatch.Players[0].ID;
          this.radioResultsPlayer2.Checked = Engine.CurrentTournMatch.Winner == Engine.CurrentTournMatch.Players[1].ID;
          this.radioResultsDraw.Checked = Engine.CurrentTournMatch.Status == TournMatchResult.Draw;
          this.radioResultsUnreported.Checked = Engine.CurrentTournMatch.Status == TournMatchResult.Incomplete;
          this.chkResultsPlayer1Drops.Checked = !Engine.CurrentTournMatch.Players[0].IsActive;
          this.chkResultsPlayer2Drops.Checked = !Engine.CurrentTournMatch.Players[1].IsActive;
          this.UI_UpdateMatchRowResult(Engine.CurrentTournMatch);
        }
        else
          this.groupBoxMatchResults.Visible = false;
      }
      this.radioResultsPlayer1.Enabled = Engine.CurrentTournMatch != null;
      this.radioResultsPlayer2.Enabled = Engine.CurrentTournMatch != null;
      this.radioResultsDraw.Enabled = Engine.CurrentTournMatch != null && !Engine.CurrentTournMatch.Players.HasPlayer(Player.BYE_ID);
      this.radioResultsDoubleLoss.Enabled = Engine.CurrentTournMatch != null;
      this.radioResultsUnreported.Enabled = Engine.CurrentTournMatch != null;
      this.chkResultsPlayer1Drops.Enabled = Engine.CurrentTournMatch != null && !Engine.CurrentTournMatch.Players[0].IsBye;
      this.chkResultsPlayer2Drops.Enabled = Engine.CurrentTournMatch != null && !Engine.CurrentTournMatch.Players[1].IsBye;
      this.subMenuMatchResult.Items["drawToolStripMenuItem"].Enabled = Engine.CurrentTournMatch != null && !Engine.CurrentTournMatch.Players.HasPlayer(Player.BYE_ID);
    }

    private void UI_UpdateStatusBar()
    {
      this.WaitCursor(true);
      if (!this.IsActiveTournament)
      {
        this.toolStripStatusActivePlayers.Text = "No Active Tournament";
        this.toolStripStatusCurrentRound.Text = "";
        this.toolStripStatusMatchCount.Text = "";
        this.toolStripStatusFinalized.Text = "";
      }
      else
      {
        ITournament activeTournament = this.ActiveTournament;
        this.toolStripStatusActivePlayers.Text = string.Format("{0} Active of {1} Total Players", (object) activeTournament.Players.ActivePlayerCount, (object) activeTournament.Players.Count);
        if (activeTournament.CurrentRound > 0)
        {
          this.toolStripStatusCurrentRound.Text = string.Format("Round {0}", (object) activeTournament.CurrentRound);
          if (activeTournament.IsPlayoffs)
            this.toolStripStatusCurrentRound.Text += " Playoffs";
          this.toolStripStatusMatchCount.Text = string.Format("{0} Unreported Matches", (object) activeTournament.Matches.UnreportedMatches.Count);
        }
        else
        {
          this.toolStripStatusCurrentRound.Text = "";
          this.toolStripStatusMatchCount.Text = "Tournament Not Started";
        }
        if (activeTournament.Finalized)
          this.toolStripStatusFinalized.Text = "Finalized";
        else
          this.toolStripStatusFinalized.Text = "";
      }
      this.WaitCursor(false);
    }

    private void UI_UpdateTabControlHeight()
    {
      this.tabTournaments.SuspendLayout();
      this.tabTournaments.Height = 16 * this.tabTournaments.RowCount + 6;
      this.tabTournaments.ResumeLayout();
      Panel[] panelArray = new Panel[4]
      {
        this.panelOpenDueling,
        this.panelPlayerEntry,
        this.panelResultsEntry,
        this.panelStandings
      };
      foreach (Panel panel in panelArray)
      {
        panel.Top = this.tabTournaments.Bottom + 1;
        panel.Height = this.mainStatusStrip.Top - this.tabTournaments.Bottom - 1;
      }
    }

    private void UI_UpdateToolbar()
    {
      foreach (ToolStripItem toolStripItem in (ArrangedElementCollection) this.mainToolStrip.Items)
        toolStripItem.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
    }

    private void UI_WizardChangeMatchResult()
    {
      if (!this.IsActiveTournament)
        return;
      ITournament activeTournament = this.ActiveTournament;
      DialogWizardChangeMatchResult changeMatchResult = new DialogWizardChangeMatchResult();
      changeMatchResult.currentTournament = activeTournament;
      int num = (int) changeMatchResult.ShowDialog();
      if (changeMatchResult.newMatches.Count <= 0)
        return;
      this._ShowPairings(activeTournament.CurrentRound);
      if (!changeMatchResult.PrintNewMatchSlips)
        return;
      this.dlgPrint.PrinterSettings = this.printDocResultSlips.PrinterSettings;
      if (this.dlgPrint.ShowDialog() != DialogResult.OK)
        return;
      Engine.LogAction(activeTournament, UserAction.Print_Result_Slips);
      this._currentPrintPage = 0;
      this._printingMatches = (ITournMatchArray) changeMatchResult.newMatches;
      this.printDocResultSlips.PrinterSettings = this.dlgPrint.PrinterSettings;
      this.printDocResultSlips.DocumentName = activeTournament.Name + " Result Slips";
      this.printDocResultSlips.Print();
    }

    private void UI_WizardUndropPlayers()
    {
      if (!this.IsActiveTournament)
        return;
      ITournament activeTournament = this.ActiveTournament;
      DialogWizardUndropPlayer wizardUndropPlayer = new DialogWizardUndropPlayer();
      wizardUndropPlayer.CurrentTournament = activeTournament;
      if (wizardUndropPlayer.ShowDialog() != DialogResult.OK)
        return;
      Engine.SaveTournamentToFile(activeTournament);
      if (wizardUndropPlayer.NewMatches.Count <= 0)
        return;
      foreach (TournMatch newMatch in (List<ITournMatch>) wizardUndropPlayer.NewMatches)
      {
        ITournMatch byRoundTable = activeTournament.Matches.GetByRoundTable(newMatch.Round, newMatch.Table);
        if (byRoundTable == null)
          activeTournament.Matches.AddMatch((ITournMatch) newMatch);
        else
          byRoundTable.Copy((ITournMatch) newMatch);
      }
      this._ShowPairings(activeTournament.CurrentRound);
      if (!wizardUndropPlayer.PrintNewMatchSlips)
        return;
      this.dlgPrint.PrinterSettings = this.printDocResultSlips.PrinterSettings;
      if (this.dlgPrint.ShowDialog() != DialogResult.OK)
        return;
      Engine.LogAction(activeTournament, UserAction.Print_Result_Slips);
      this._currentPrintPage = 0;
      this._printingMatches = (ITournMatchArray) wizardUndropPlayer.NewMatches;
      this.printDocResultSlips.PrinterSettings = this.dlgPrint.PrinterSettings;
      this.printDocResultSlips.DocumentName = activeTournament.Name + " Result Slips";
      this.printDocResultSlips.Print();
    }

    private void dgMatches_CellContextMenuStripNeeded(
      object sender,
      DataGridViewCellContextMenuStripNeededEventArgs e)
    {
      if (e.RowIndex < 0 || e.RowIndex >= this.dgMatches.Rows.Count)
        return;
      this.dgMatches.ClearSelection();
      this.dgMatches.Rows[e.RowIndex].Selected = true;
      int result = 0;
      if (int.TryParse(this.dgMatches.Rows[e.RowIndex].Cells["Table"].ToString(), out result))
      {
        this.txtResultsEntryTable.Text = result.ToString();
        this.UpdateCurrentMatch();
      }
      this.UI_UpdateResultsEntry();
    }

    private void dgMatches_KeyPress(object sender, KeyPressEventArgs e)
    {
      char keyChar = e.KeyChar;
      if ("-+=*/".IndexOf(keyChar) < 0)
        return;
      e.Handled = true;
      this.TableResultKeyHandled = true;
      this._ProcessResultEntryCommand(keyChar);
    }

    private void dgMatches_KeyUp(object sender, KeyEventArgs e)
    {
      Console.WriteLine("dgMatches Results Entry Keyup: {0}{1}{2}{3} ({4})", e.Control ? (object) "Ctrl-" : (object) "", e.Alt ? (object) "Alt-" : (object) "", e.Shift ? (object) "Shift-" : (object) "", (object) Enum.GetName(typeof (Keys), (object) e.KeyCode), (object) e.KeyCode);
      try
      {
        if (!this.TableResultKeyHandled)
        {
          this.UI_UpdateResultsEntry();
          switch (e.KeyCode)
          {
            case Keys.Add:
              this._ProcessResultEntryCommand('+', e);
              break;
            case Keys.Subtract:
              this._ProcessResultEntryCommand('-', e);
              break;
            case Keys.Divide:
              this._ProcessResultEntryCommand('/', e);
              break;
            case Keys.Oemplus:
              this._ProcessResultEntryCommand('+', e);
              break;
            case Keys.OemMinus:
              this._ProcessResultEntryCommand('-', e);
              break;
            case Keys.OemQuestion:
              this._ProcessResultEntryCommand('/', e);
              break;
          }
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(string.Format("Error in dgMatches_KeyUp: {0}", (object) ex.Message));
      }
      this.TableResultKeyHandled = false;
    }

    private void dgMatches_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
    {
      try
      {
        if (e.StateChanged != DataGridViewElementStates.Selected || !e.Row.Selected || e.Row == null)
          return;
        if (e.Row.Cells["MatchObject"].Value != null)
        {
          ITournMatch tournMatch = (ITournMatch) e.Row.Cells["MatchObject"].Value;
          if (this.IsActiveTournament)
            this.txtResultsEntryTable.Text = Convert.ToString(this.ActiveTournament.TableOffset + tournMatch.Table);
          else
            this.txtResultsEntryTable.Text = tournMatch.Table.ToString();
          this.UpdateCurrentMatch();
        }
        this.UI_UpdateResultsEntry();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(string.Format("Error in selecting a new row: {0}", (object) ex.Message));
      }
    }

    private void dgOpenDueling_KeyDown(object sender, KeyEventArgs e)
    {
      this.OpenDuelingKeyDown(e);
    }

    private void dgOpenDueling_SelectionChanged(object sender, EventArgs e)
    {
      if (this.dgOpenDueling.SelectedRows.Count <= 0)
        return;
      this.ShowOpenDuelingPlayer();
    }

    private void txtAllPlayerSearch_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar != '\r' && e.KeyChar != '\n')
        return;
      e.Handled = true;
      this._PerformPlayerSearch();
    }

    private void txtCurrentPlayerFirstName_KeyUp(object sender, KeyEventArgs e)
    {
      this.KeyPressPlayerEnroll(e, this.txtCurrentPlayerFirstName, this.txtCurrentPlayerLastName, true);
    }

    private void txtCurrentPlayerID_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (char.IsDigit(e.KeyChar) && !this._PlayerIdEntered || e.KeyChar != '\r' && e.KeyChar != '\n')
        return;
      if (this._PlayerIdEntered)
      {
        long playerId = this.ParsePlayerId(this.txtCurrentPlayerID.Text);
        if (Engine.GetCossyIdType(playerId) == Engine.CossyIdType.None && MessageBox.Show(string.Format("{0}: Invalid COSSY ID, Continue?", (object) Utility.MakeDisplayCOSSY(playerId)), "Error", MessageBoxButtons.YesNo) == DialogResult.No)
          e.Handled = true;
        else if (playerId != Player.BYE_ID)
        {
          IPlayer byId = Engine.PlayerList.FindById(playerId);
          if (byId != null)
          {
            Engine.CurrentPlayer = byId;
            this._EnrollSelectedPlayer();
            e.Handled = true;
          }
          else
          {
            DialogNewPerson dialogNewPerson = new DialogNewPerson();
            dialogNewPerson.PlayerId = this.txtCurrentPlayerID.Text;
            if (dialogNewPerson.ShowDialog() == DialogResult.OK)
            {
              Engine.CurrentPlayer = dialogNewPerson.NewPlayer;
              Engine.PlayerList.AddPlayer(Engine.CurrentPlayer);
              this._EnrollSelectedPlayer();
              this._ShowAdditionalPlayer(Engine.CurrentPlayer);
            }
            e.Handled = true;
          }
        }
        else
        {
          int num = (int) MessageBox.Show("Error reading Player ID");
        }
      }
      else
        e.Handled = true;
    }

    private void txtCurrentPlayerID_TextChanged(object sender, EventArgs e)
    {
      if (this._PlayerIdEntered)
      {
        IPlayer byId = Engine.PlayerList.FindById(this.ParsePlayerId(this.txtCurrentPlayerID.Text));
        if (byId != null && !byId.IsBye)
        {
          Engine.CurrentPlayer = byId;
          this.txtCurrentPlayerFirstName.Text = byId.FirstName;
          this.txtCurrentPlayerLastName.Text = byId.LastName;
        }
        else
        {
          Engine.CurrentPlayer = (IPlayer) null;
          this.txtCurrentPlayerFirstName.Text = string.Empty;
          this.txtCurrentPlayerLastName.Text = string.Empty;
        }
      }
      else
      {
        Engine.CurrentPlayer = (IPlayer) null;
        this.txtCurrentPlayerFirstName.Text = string.Empty;
        this.txtCurrentPlayerLastName.Text = string.Empty;
      }
    }

    private void txtCurrentPlayerLastName_KeyUp(object sender, KeyEventArgs e)
    {
      this.KeyPressPlayerEnroll(e, this.txtCurrentPlayerFirstName, this.txtCurrentPlayerLastName, true);
    }

    private void txtOpenDuelingFirstname_KeyDown(object sender, KeyEventArgs e)
    {
      this.OpenDuelingKeyDown(e);
    }

    private void txtOpenDuelingFirstname_KeyUp(object sender, KeyEventArgs e)
    {
      this.OpenDuelingKeyUp(e, this.txtOpenDuelingFirstname, this.txtOpenDuelingLastName, true);
    }

    private void txtOpenDuelingLastName_KeyDown(object sender, KeyEventArgs e)
    {
      this.OpenDuelingKeyDown(e);
    }

    private void txtOpenDuelingLastName_KeyUp(object sender, KeyEventArgs e)
    {
      this.OpenDuelingKeyUp(e, this.txtOpenDuelingLastName, this.txtOpenDuelingFirstname, false);
    }

    private void txtResultsEntryTable_KeyPress(object sender, KeyPressEventArgs e)
    {
      Console.Out.WriteLine(nameof (txtResultsEntryTable_KeyPress));
      try
      {
        char keyChar = e.KeyChar;
        if ("-+=*/".IndexOf(keyChar) < 0)
          return;
        e.Handled = true;
        this.TableResultKeyHandled = true;
        this._ProcessResultEntryCommand(keyChar);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(string.Format("Error in txtResultsEntryTable_KeyPress: {0}", (object) ex.Message));
      }
    }

    private void txtResultsEntryTable_KeyUp(object sender, KeyEventArgs e)
    {
      Console.WriteLine("Results Entry Keyup: {0}{1}{2}{3} ({4})", e.Control ? (object) "Ctrl-" : (object) "", e.Alt ? (object) "Alt-" : (object) "", e.Shift ? (object) "Shift-" : (object) "", (object) Enum.GetName(typeof (Keys), (object) e.KeyCode), (object) e.KeyCode);
      try
      {
        if (!this.TableResultKeyHandled)
        {
          this.UI_UpdateResultsEntry();
          switch (e.KeyCode)
          {
            case Keys.Add:
              this._ProcessResultEntryCommand('+', e);
              break;
            case Keys.Subtract:
              this._ProcessResultEntryCommand('-', e);
              break;
            case Keys.Divide:
              this._ProcessResultEntryCommand('/', e);
              break;
            case Keys.Oemplus:
              this._ProcessResultEntryCommand('+', e);
              break;
            case Keys.OemMinus:
              this._ProcessResultEntryCommand('-', e);
              break;
            case Keys.OemQuestion:
              this._ProcessResultEntryCommand('/', e);
              break;
          }
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(string.Format("Error in txtResultsEntryTable_KeyUp: {0}", (object) ex.Message));
      }
      this.TableResultKeyHandled = false;
    }

    public MainForm()
    {
      this.InitializeComponent();
      this.idleEventHandler = new EventHandler(this.OnIdle);
      Application.Idle += this.idleEventHandler;
      this._xmlReaderSettings.CloseInput = true;
      this._xmlReaderSettings.IgnoreWhitespace = true;
      this._xmlWriterSettings.Encoding = Encoding.UTF8;
      this._xmlWriterSettings.OmitXmlDeclaration = false;
      this._xmlWriterSettings.Indent = true;
      this._xmlWriterSettings.IndentChars = "\t";
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      Engine.LogAction((ITournament) null, UserAction.Program_Stop);
      Application.Idle -= this.idleEventHandler;
      MainForm._SavePlayerList(true);
      this._SaveLocationList(true);
      for (int index = Engine.AllTournaments.Count - 1; index >= 0; --index)
        this.TournamentClose(Engine.AllTournaments[index]);
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
      this.UI_UpdateToolbar();
      if (Konami.Properties.Settings.Default.DataStorageFolder == string.Empty || Konami.Properties.Settings.Default.DataStorageFolder == "(no folder)")
      {
        if (TournamentLibrary.BusinessLogic.Settings.GetRegKey("DataDirectory") != string.Empty)
        {
          Konami.Properties.Settings.Default.DataStorageFolder = TournamentLibrary.BusinessLogic.Settings.GetRegKey("DataDirectory");
          Konami.Properties.Settings.Default.Save();
          Konami.Properties.Settings.Default.Reload();
        }
        else
        {
          this.folderBrowserDialog1.Description = "Choose the destination of Konami Tournament Data folder";
          this.folderBrowserDialog1.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
          if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
          {
            string str = Path.Combine(this.folderBrowserDialog1.SelectedPath, "Konami Software");
            TournamentLibrary.BusinessLogic.Settings.SetRegKey("DataDirectory", (object) str);
            Konami.Properties.Settings.Default.DataStorageFolder = str;
            Konami.Properties.Settings.Default.Save();
            Konami.Properties.Settings.Default.Reload();
          }
        }
      }
      this.CopySettings();
      Engine.LogAction((ITournament) null, UserAction.Program_Start, (object) "Version ", (object) Assembly.GetExecutingAssembly().GetName().Version.ToString());
      if (File.Exists(Engine.PlayerListFilename))
        Engine.PlayerList.AddRange(PlayerArray.LoadFromFile(Engine.PlayerListFilename));
      Engine.PlayerList.SortByLastname();
      this._ShowGlobalPlayers();
      this.tabTournaments.TabPages.Add("0", "All Players");
      this._PanelsSetPanel((ITournament) null, MainForm.PanelTypes.EnrollPlayer);
      if (File.Exists(Engine.LocationListFilename))
      {
        XmlDocument xmlDocument = new XmlDocument();
        XmlReader reader = XmlReader.Create((TextReader) new StreamReader(Engine.LocationListFilename), this._xmlReaderSettings);
        xmlDocument.Load(reader);
        reader.Close();
        XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName(Engine.LocationList.XmlKeyElementName);
        if (elementsByTagName.Count > 0)
        {
          LocationArray locationArray = new LocationArray();
          locationArray.FromXml(elementsByTagName[0]);
          foreach (Location location in (List<ILocation>) locationArray)
          {
            if (!location.IsEmpty)
              Engine.LocationList.Add((ILocation) location);
          }
          Engine.LocationList.Sort();
        }
      }
      this.UI_Cleanup();
      int bottom = this.tabTournaments.Bottom;
      int left = this.tabTournaments.Left;
      int width = this.tabTournaments.Right - this.tabTournaments.Left;
      int height = this.mainStatusStrip.Top + 1 - bottom;
      Panel[] panelArray = new Panel[4]
      {
        this.panelPlayerEntry,
        this.panelResultsEntry,
        this.panelStandings,
        this.panelOpenDueling
      };
      foreach (Panel panel in panelArray)
      {
        panel.Location = new Point(left, bottom);
        panel.Size = new Size(width, height);
        panel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        panel.Visible = false;
      }
      this.ShowPanel(MainForm.PanelTypes.EnrollPlayer);
    }

    private void MainForm_Resize(object sender, EventArgs e)
    {
      this.UI_UpdateTabControlHeight();
    }

    private void PrintSeatAllPlayers()
    {
      if (!this.IsActiveTournament)
        return;
      ITournament activeTournament = this.ActiveTournament;
      activeTournament.CreateSeatAllPlayers();
      this.dlgPrint.PrinterSettings = this.printDocPairings.PrinterSettings;
      if (this.dlgPrint.ShowDialog() != DialogResult.OK)
        return;
      Engine.PlayerList.SortByLastname();
      this.printDocPairings.PrinterSettings = this.dlgPrint.PrinterSettings;
      activeTournament.Matches.GetByRound(0);
      this._PrintPairings(activeTournament, Engine.PrintPairingsAction.PrintByPlayer, (int) this.dlgPrint.PrinterSettings.Copies, this.dlgPrint.PrinterSettings.PrinterName);
    }

    private void PrintStandings()
    {
      if (!this.IsActiveTournament)
        return;
      this.dlgPrintStandings.Collate = this.printDocStandings.PrinterSettings.Collate;
      this.dlgPrintStandings.SelectedPrinter = this.printDocStandings.PrinterSettings.PrinterName;
      if (this.dlgPrintStandings.ShowDialog() != DialogResult.OK)
        return;
      this._PrintStandings(this.ActiveTournament, (int) this.dlgPrintStandings.Copies, this.printDocStandings.PrinterSettings.PrinterName, this.dlgPrintStandings.AllPlayers, this.dlgPrintStandings.PrintAllPages);
    }

    private void PrintStringToFit(
      string text,
      Font currentFont,
      SolidBrush brush,
      float xPos,
      float yPos,
      float maxWidth,
      PrintPageEventArgs ev)
    {
      Graphics graphics = ev.Graphics;
      SizeF sizeF = graphics.MeasureString(text, currentFont);
      if ((double) sizeF.Width > (double) maxWidth)
      {
        float sx = maxWidth / sizeF.Width;
        Point renderingOrigin = graphics.RenderingOrigin;
        graphics.RenderingOrigin = new Point((int) xPos, (int) yPos);
        graphics.ScaleTransform(sx, 1f);
        float x = xPos / sx;
        ev.Graphics.DrawString(text, currentFont, (Brush) brush, x, yPos);
        graphics.ScaleTransform(1f / sx, 1f);
        graphics.RenderingOrigin = renderingOrigin;
      }
      else
        ev.Graphics.DrawString(text, currentFont, (Brush) brush, xPos, yPos);
    }

    private void printDocBrackets_PrintPage(ITournMatchArray matches, PrintPageEventArgs ev)
    {
      float result = 12f;
      float.TryParse(Konami.Properties.Settings.Default.PrinterFontSize, out result);
      Font font1 = new Font(Konami.Properties.Settings.Default.PrinterFont, result, FontStyle.Bold, GraphicsUnit.Point);
      Font currentFont = new Font(Konami.Properties.Settings.Default.PrinterFont, result, GraphicsUnit.Point);
      Font font2 = new Font(Konami.Properties.Settings.Default.PrinterFont, result, FontStyle.Italic, GraphicsUnit.Point);
      SolidBrush brush = new SolidBrush(Color.Black);
      Pen pen = new Pen((Brush) brush);
      float left = (float) ev.MarginBounds.Left;
      int top = ev.MarginBounds.Top;
      float height = currentFont.GetHeight(ev.Graphics);
      int num1 = matches.Count * 2;
      int num2 = Convert.ToInt32(Math.Log((double) num1, 2.0)) + 1;
      float num3 = (float) (ev.MarginBounds.Width / num2);
      float num4 = (float) ev.MarginBounds.Top + height * 4f;
      float num5 = (float) ev.MarginBounds.Bottom - height * 4f;
      for (int index1 = 0; index1 < num2; ++index1)
      {
        float num6 = (num5 - num4) / (float) num1;
        for (int index2 = 0; index2 < num1; ++index2)
        {
          float x1 = left + (float) index1 * num3;
          float y1 = (float) ((double) num4 + (double) index2 * (double) num6 + (double) num6 / 2.0);
          float num7 = left + (float) (index1 + 1) * num3;
          float num8 = y1;
          ev.Graphics.DrawLine(pen, x1, y1, num7, num8);
          if (index2 % 2 == 0 && index1 < num2 - 1)
            ev.Graphics.DrawLine(pen, num7, num8, num7, num8 + num6);
          if (index1 == 0)
          {
            ITournMatch printingMatch = this._printingMatches[index2 / 2];
            float x = x1 + height * 0.5f;
            float num9 = Math.Min(height * 0.5f, (float) (((double) num6 - (double) height) / 2.0)) + height;
            float y = y1 - num9;
            RectangleF rectangleF = new RectangleF(x, y, num7 - x, num8 - y);
            string fullName = printingMatch.Players[0].FullName;
            if (index2 % 2 != 0)
              fullName = printingMatch.Players[1].FullName;
            this.PrintStringToFit(fullName, currentFont, brush, rectangleF.X, rectangleF.Y, rectangleF.Width, ev);
          }
        }
        num1 /= 2;
      }
    }

    private void printDocPairings_PrintPage(object sender, PrintPageEventArgs ev)
    {
      float result = 9f;
      float.TryParse(Konami.Properties.Settings.Default.PrinterFontSize, out result);
      Font font1 = new Font(Konami.Properties.Settings.Default.PrinterFont, result, FontStyle.Bold, GraphicsUnit.Point);
      Font font2 = new Font(Konami.Properties.Settings.Default.PrinterFont, result, GraphicsUnit.Point);
      Font font3 = new Font(Konami.Properties.Settings.Default.PrinterFont, result, FontStyle.Italic, GraphicsUnit.Point);
      SolidBrush brush = new SolidBrush(Color.Black);
      float left = (float) ev.MarginBounds.Left;
      float top = (float) ev.MarginBounds.Top;
      float num1 = top;
      float height = font2.GetHeight(ev.Graphics);
      int num2 = Convert.ToInt32((float) ((double) ev.MarginBounds.Height + (double) height - 1.0) / height) - 5;
      int num3 = 0;
      if (this.IsActiveTournament)
      {
        ITournament activeTournament = this.ActiveTournament;
        activeTournament.Players.SortByLastname();
        this._printingMatches.SortByRoundTable();
        if (this._currentPairingsPrint == Engine.PrintPairingsAction.PrintBrackets)
        {
          string s = string.Format("{0} Brackets", (object) activeTournament.Name);
          ev.Graphics.DrawString(s, font1, (Brush) brush, left, top);
          this.printDocBrackets_PrintPage(this._printingMatches, ev);
          ++this._currentPrintCopy;
          ev.HasMorePages = this._currentPrintCopy < this._maxPrintCopy;
        }
        else
        {
          string s1 = ((PrintDocument) sender).DocumentName;
          if (this._currentPairingsPrint == Engine.PrintPairingsAction.PrintByPlayer && activeTournament.PrinterSplits.SplitCount > 0)
            s1 = string.Format("{0} - {1} to {2}", (object) s1, (object) activeTournament.PrinterSplits[this._currentPrintSplitGroup].FirstChar, (object) activeTournament.PrinterSplits[this._currentPrintSplitGroup].LastChar);
          ev.Graphics.DrawString(s1, font1, (Brush) brush, left, top);
          if (this._currentPairingsPrint == Engine.PrintPairingsAction.PrintByPlayer)
            num3 = (this._printingPlayerList.Count + num2 - 1) / num2;
          else if (this._currentPairingsPrint == Engine.PrintPairingsAction.PrintByTable)
            num3 = (this._printingMatches.Count + num2 - 1) / num2;
          else if (this._currentPairingsPrint == Engine.PrintPairingsAction.PrintUnreported)
            num3 = (this._printingMatches.Count + num2 - 1) / num2;
          else if (this._currentPairingsPrint == Engine.PrintPairingsAction.None)
          {
            ev.HasMorePages = false;
            return;
          }
          float num4 = height;
          float x = left;
          float xPos1 = left + ev.Graphics.MeasureString("Table XXXX: ", font2).Width;
          float xPos2 = xPos1 + (float) (((double) ev.MarginBounds.Right - (double) xPos1) / 2.0);
          float maxWidth = xPos2 - xPos1 - num4;
          float num5 = num1 + 2f * height;
          int num6 = this._currentPrintPairingsRow + num2;
          string lastname = string.Empty;
          do
          {
            string empty1 = string.Empty;
            string empty2 = string.Empty;
            string empty3 = string.Empty;
            ITournPlayer player1;
            ITournMatch printingMatch;
            if (this._currentPairingsPrint == Engine.PrintPairingsAction.PrintByPlayer)
            {
              if (this._currentPrintPairingsRow < this._printingPlayerList.Count)
              {
                player1 = this._printingPlayerList[this._currentPrintPairingsRow];
                if (activeTournament.PrinterSplits.SplitCount > 0)
                {
                  lastname = player1.LastName;
                  if (!activeTournament.PrinterSplits.IsInGroup(lastname, this._currentPrintSplitGroup))
                    break;
                }
                ITournMatchArray byPlayer = this._printingMatches.GetByPlayer(player1.ID);
                if (byPlayer.Count == 0)
                {
                  ++this._currentPrintPairingsRow;
                  goto label_33;
                }
                else
                  printingMatch = byPlayer[0];
              }
              else
                break;
            }
            else if (this._printingMatches.Count > this._currentPrintPairingsRow)
            {
              printingMatch = this._printingMatches[this._currentPrintPairingsRow];
              player1 = printingMatch.Players[0];
            }
            else
              break;
            ITournPlayer player2 = player1.ID == printingMatch.Players[0].ID ? (printingMatch.Players.Count >= 2 ? printingMatch.Players[1] : (ITournPlayer) new TournPlayer((IPlayer) Player.ByePlayer)) : printingMatch.Players[0];
            string s2 = string.Format("Table {0}", (object) (activeTournament.TableOffset + printingMatch.Table));
            string text1;
            string text2;
            if (printingMatch.Round > 1)
            {
              text1 = MainForm.FormatNameWithWins(player1);
              text2 = MainForm.FormatNameWithWins(player2);
            }
            else if (TournamentLibrary.BusinessLogic.Settings.ShowPlayerIds_ShowOnPrintouts)
            {
              text1 = player1.FullNameWithId;
              text2 = player2.FullNameWithId;
            }
            else
            {
              text1 = player1.FullName;
              text2 = player2.FullName;
            }
            if (player1 != null && !player1.IsBye)
            {
              ev.Graphics.DrawString(s2, font2, (Brush) brush, x, num5);
              this.PrintStringToFit(text1, font2, brush, xPos1, num5, maxWidth, ev);
              if (printingMatch.Round > 0 || !player2.IsBye)
                this.PrintStringToFit(text2, font2, brush, xPos2, num5, maxWidth, ev);
              num5 += height;
            }
            ++this._currentPrintPairingsRow;
label_33:;
          }
          while (this._currentPrintPairingsRow < num6);
          float num7 = num5 + height;
          if (activeTournament.PrinterSplits.SplitCount > 0)
          {
            string s2 = string.Format("Page {0}", (object) (this._currentPrintPage + 1), (object) num3);
            ev.Graphics.DrawString(s2, font3, (Brush) brush, left, (float) ev.MarginBounds.Bottom - height);
          }
          else
          {
            string s2 = string.Format("Page {0} of {1}", (object) (this._currentPrintPage + 1), (object) num3);
            ev.Graphics.DrawString(s2, font3, (Brush) brush, left, (float) ev.MarginBounds.Bottom - height);
          }
          string shortTimeString = DateTime.Now.ToShortTimeString();
          ev.Graphics.DrawString(shortTimeString, font3, (Brush) brush, (float) ev.MarginBounds.Right - ev.Graphics.MeasureString(shortTimeString, font3).Width, (float) ev.MarginBounds.Bottom - height);
          ++this._currentPrintPage;
          if (this._currentPairingsPrint == Engine.PrintPairingsAction.PrintByPlayer)
          {
            if (activeTournament.PrinterSplits.SplitCount > 0)
            {
              if (!activeTournament.PrinterSplits.IsInGroup(lastname, this._currentPrintSplitGroup))
                ++this._currentPrintSplitGroup;
              if (this._currentPrintSplitGroup >= activeTournament.PrinterSplits.SplitCount || this._currentPrintPairingsRow >= this._printingPlayerList.Count)
              {
                this._currentPrintPairingsRow = 0;
                ++this._currentPrintCopy;
                this._currentPrintPage = 0;
                this._currentPrintSplitGroup = 0;
              }
            }
            else if (this._currentPrintPairingsRow >= this._printingPlayerList.Count)
            {
              this._currentPrintPairingsRow = 0;
              ++this._currentPrintCopy;
              this._currentPrintPage = 0;
            }
          }
          else if (this._currentPrintPairingsRow >= this._printingMatches.Count)
          {
            this._currentPrintPairingsRow = 0;
            ++this._currentPrintCopy;
            this._currentPrintPage = 0;
          }
          ev.HasMorePages = this._currentPrintCopy < this._maxPrintCopy;
        }
      }
      else
        ev.HasMorePages = false;
    }

    private void printDocPlayerList_PrintPage(object sender, PrintPageEventArgs ev)
    {
      if (!this.IsActiveTournament)
      {
        ev.HasMorePages = false;
      }
      else
      {
        ITournament activeTournament = this.ActiveTournament;
        bool flag = ev.PageSettings.PrinterSettings.PrintRange == PrintRange.AllPages;
        if (ev.PageSettings.PrinterSettings.PrintRange == PrintRange.SomePages)
        {
          int num = this._currentPrintPage + 1;
          flag = num >= ev.PageSettings.PrinterSettings.FromPage && num <= ev.PageSettings.PrinterSettings.ToPage;
          ev.HasMorePages = num < ev.PageSettings.PrinterSettings.ToPage;
        }
        if (flag)
        {
          if (this.dlgPrintPlayers.SortById)
            activeTournament.Players.SortByID();
          else
            activeTournament.Players.SortByLastname();
          float result = 12f;
          float.TryParse(Konami.Properties.Settings.Default.PrinterFontSize, out result);
          Font font1 = new Font(Konami.Properties.Settings.Default.PrinterFont, result, FontStyle.Bold, GraphicsUnit.Point);
          Font font2 = new Font(Konami.Properties.Settings.Default.PrinterFont, result, GraphicsUnit.Point);
          Font font3 = new Font(Konami.Properties.Settings.Default.PrinterFont, result, FontStyle.Italic, GraphicsUnit.Point);
          SolidBrush solidBrush = new SolidBrush(Color.Black);
          float left = (float) ev.MarginBounds.Left;
          float top = (float) ev.MarginBounds.Top;
          float height = font2.GetHeight(ev.Graphics);
          int int32 = Convert.ToInt32((float) ev.MarginBounds.Height / height);
          int num1 = int32 - 4;
          int num2 = this._currentPrintPage * num1;
          int num3 = num2 + num1;
          PrintDocument printDocument = (PrintDocument) sender;
          ITournPlayerArray tournPlayerArray = !this.dlgPrintPlayers.ActivePlayers ? activeTournament.Players : activeTournament.ActivePlayers;
          ev.Graphics.DrawString(printDocument.DocumentName, font1, (Brush) solidBrush, left, top);
          float y1 = top + 2f * height;
          for (int index = num2; index < num3; ++index)
          {
            if (tournPlayerArray.Count > index)
            {
              if (this.dlgPrintPlayers.SortById)
              {
                ev.Graphics.DrawString(tournPlayerArray[index].IDFormatted, font2, (Brush) solidBrush, left, y1);
                ev.Graphics.DrawString(tournPlayerArray[index].FullName, font2, (Brush) solidBrush, left + (float) ev.MarginBounds.Width * 0.25f, y1);
              }
              else if (TournamentLibrary.BusinessLogic.Settings.ShowPlayerIds_ShowOnPrintouts)
                ev.Graphics.DrawString(tournPlayerArray[index].FullNameWithId, font2, (Brush) solidBrush, left, y1);
              else
                ev.Graphics.DrawString(tournPlayerArray[index].FullName, font2, (Brush) solidBrush, left, y1);
              y1 += height;
              ev.HasMorePages = true;
            }
            else
              ev.HasMorePages = false;
          }
          ++this._currentPrintPage;
          float y2 = y1 + height;
          string s = string.Format("Page {0} of {1}               {2}", (object) this._currentPrintPage, (object) ((tournPlayerArray.Count + int32 - 1) / int32), (object) DateTime.Now.ToShortTimeString());
          ev.Graphics.DrawString(s, font3, (Brush) solidBrush, left, y2);
        }
        else
          ++this._currentPrintPage;
      }
    }

    private void printDocPlayerNotes_PrintPage(object sender, PrintPageEventArgs ev)
    {
      if (!this.IsActiveTournament)
      {
        ev.HasMorePages = false;
      }
      else
      {
        float result = 9f;
        float.TryParse(Konami.Properties.Settings.Default.PrinterFontSize, out result);
        Font font1 = new Font(Konami.Properties.Settings.Default.PrinterFont, result, FontStyle.Bold, GraphicsUnit.Point);
        Font font2 = new Font(Konami.Properties.Settings.Default.PrinterFont, result, GraphicsUnit.Point);
        Font font3 = new Font(Konami.Properties.Settings.Default.PrinterFont, result, FontStyle.Italic, GraphicsUnit.Point);
        SolidBrush solidBrush = new SolidBrush(Color.Black);
        Pen pen = new Pen((Brush) solidBrush);
        float height = font2.GetHeight(ev.Graphics);
        float left = (float) ev.MarginBounds.Left;
        float top = (float) ev.MarginBounds.Top;
        float num1 = top + 2f * height;
        float num2 = num1;
        PrintDocument printDocument = (PrintDocument) sender;
        ev.Graphics.DrawString(printDocument.DocumentName, font1, (Brush) solidBrush, left, top);
        ITournament activeTournament = this.ActiveTournament;
        activeTournament.Penalties.Sort();
        ev.HasMorePages = false;
        for (int printPlayerNotes = this._currentPrintPlayerNotes; printPlayerNotes < activeTournament.Penalties.Count; ++printPlayerNotes)
        {
          IPenalty penalty = activeTournament.Penalties[printPlayerNotes];
          SizeF size = ev.Graphics.MeasureString(penalty.Notes, font2, ev.MarginBounds.Width);
          if ((double) size.Height + 3.0 * (double) height < (double) ev.MarginBounds.Height - (double) num2 || (double) num2 == (double) num1)
          {
            ev.Graphics.DrawLine(pen, (int) left, (int) num2, ev.MarginBounds.Right, (int) num2);
            string s1 = penalty.Player.FullName;
            if (TournamentLibrary.BusinessLogic.Settings.ShowPlayerIds_ShowOnPrintouts)
              s1 = penalty.Player.FullNameWithId;
            float y1 = num2 + height;
            ev.Graphics.DrawString(s1, font1, (Brush) solidBrush, left, y1);
            float y2 = y1 + height;
            string s2 = string.Format("Round {0} {1} {2}, Judge: {3}", (object) penalty.Round, (object) PenaltyClass.GetName(penalty.Infraction), (object) CommonEnumLists.PenaltyEnumNames[penalty.Penalty], (object) penalty.Judge.FullName);
            ev.Graphics.DrawString(s2, font2, (Brush) solidBrush, left, y2);
            float y3 = y2 + height;
            if (!string.IsNullOrEmpty(penalty.Notes))
            {
              ev.Graphics.DrawString(penalty.Notes, font3, (Brush) solidBrush, new RectangleF(new PointF((float) ev.MarginBounds.Left, y3), size));
              y3 += height;
            }
            num2 = y3 + height;
            ev.Graphics.DrawLine(pen, (int) left, (int) num2, ev.MarginBounds.Right, (int) num2);
            this._currentPrintPlayerNotes = printPlayerNotes + 1;
            if ((double) num2 > (double) ev.MarginBounds.Bottom)
            {
              ev.HasMorePages = true;
              break;
            }
          }
          else
          {
            ev.HasMorePages = true;
            break;
          }
        }
        string s = string.Format("Page {0}", (object) this._currentPrintPage++);
        float y = (float) ev.MarginBounds.Bottom - height;
        ev.Graphics.DrawString(s, font3, (Brush) solidBrush, left, y);
        string shortTimeString = DateTime.Now.ToShortTimeString();
        ev.Graphics.DrawString(shortTimeString, font3, (Brush) solidBrush, (float) ev.MarginBounds.Right - ev.Graphics.MeasureString(shortTimeString, font3).Width, y);
      }
    }

    private void printDocResultSlips_PrintPage(object sender, PrintPageEventArgs ev)
    {
      if (!this.IsActiveTournament)
      {
        ev.HasMorePages = false;
      }
      else
      {
        string str1 = "Winner";
        string str2 = "Judge";
        string str3 = "Drop";
        string str4 = "Signature";
        string str5 = "Penalties?";
        string str6 = "Time Extension";
        string str7 = "Draw";
        this._printingMatches.SortByRoundTable();
        float result = 10f;
        float.TryParse(TournamentLibrary.BusinessLogic.Settings.PrinterFontSize, out result);
        Font font1 = new Font(Konami.Properties.Settings.Default.PrinterFont, result, FontStyle.Bold, GraphicsUnit.Point);
        Font font2 = new Font(Konami.Properties.Settings.Default.PrinterFont, result, GraphicsUnit.Point);
        SolidBrush solidBrush = new SolidBrush(Color.Black);
        float height = font2.GetHeight(ev.Graphics);
        float num1 = height / 2f;
        int num2 = 4;
        int currentPrintPage = this._currentPrintPage;
        ITournament activeTournament = this.ActiveTournament;
        float width1 = ev.Graphics.MeasureString(activeTournament.Name, font1).Width;
        SizeF sizeF = ev.Graphics.MeasureString("Table XXXX", font1);
        float width2 = sizeF.Width;
        sizeF = ev.Graphics.MeasureString(str1, font2);
        float width3 = sizeF.Width;
        sizeF = ev.Graphics.MeasureString(str2, font2);
        double width4 = (double) sizeF.Width;
        sizeF = ev.Graphics.MeasureString(str3, font2);
        float width5 = sizeF.Width;
        sizeF = ev.Graphics.MeasureString(str4, font2);
        float width6 = sizeF.Width;
        sizeF = ev.Graphics.MeasureString(str5, font2);
        float width7 = sizeF.Width;
        sizeF = ev.Graphics.MeasureString(str6, font2);
        float width8 = sizeF.Width;
        sizeF = ev.Graphics.MeasureString(str7, font2);
        float width9 = sizeF.Width;
        Rectangle marginBounds = ev.MarginBounds;
        float left1 = (float) marginBounds.Left;
        marginBounds = ev.MarginBounds;
        float right = (float) marginBounds.Right;
        marginBounds = ev.MarginBounds;
        float num3 = (float) marginBounds.Height / (float) num2;
        float num4 = num3 / 9f;
        float num5 = right - left1;
        float num6 = left1 * 1.5f;
        float x1 = left1;
        float x2 = right - width5;
        float num7 = right - height;
        float x3 = (float) ((double) left1 + (double) num5 / 2.0 - (double) width1 / 2.0);
        float num8 = left1 + num5 / 2f;
        float x4 = num8 + height;
        float x5 = right - width2;
        float x6 = left1;
        float x7 = x1 + height + num1;
        float x8 = num7 - height - num1 - width7;
        float num9 = x7 + width8 + height;
        float num10 = x2 - num8 - num1;
        float width10 = num8 - x7 - num1;
        int num11 = (this._printingMatches.Count + 4 - 1) / 4;
        Pen pen1 = new Pen((Brush) solidBrush);
        Graphics graphics1 = ev.Graphics;
        Pen pen2 = pen1;
        marginBounds = ev.MarginBounds;
        int left2 = marginBounds.Left;
        marginBounds = ev.MarginBounds;
        int top1 = marginBounds.Top;
        int x2_1 = (int) right;
        marginBounds = ev.MarginBounds;
        int top2 = marginBounds.Top;
        graphics1.DrawLine(pen2, left2, top1, x2_1, top2);
        for (int index1 = 0; index1 < num2; ++index1)
        {
          marginBounds = ev.MarginBounds;
          int num12 = (int) ((double) marginBounds.Top + (double) index1 * (double) num3);
          int index2 = currentPrintPage + index1 * num11;
          if (index2 < this._printingMatches.Count)
          {
            ITournMatch printingMatch = this._printingMatches[index2];
            if (!printingMatch.Players[0].IsBye && !printingMatch.Players[1].IsBye)
            {
              float num13 = (float) num12 + num3;
              float num14 = (float) num12 + num4 / 2f;
              float num15 = num14 + num4 + num4;
              float num16 = num15 + num4;
              float num17 = num16 + num4 + num4;
              float num18 = num17 + num4 + num4;
              float y1 = num14 + num4 / 2f - num1;
              float y2 = y1 + num4;
              float y3 = y2 + num4;
              float y4 = y3 + num4;
              float y5 = y4 + num4;
              float y6 = y5 + num4;
              float y7 = y6 + num4;
              string str8 = printingMatch.Players[0].FullName;
              string str9 = printingMatch.Players[1].FullName;
              if (TournamentLibrary.BusinessLogic.Settings.ShowPlayerIds_ShowOnPrintouts)
              {
                str8 = printingMatch.Players[0].FullNameWithId;
                str9 = printingMatch.Players[1].FullNameWithId;
              }
              ev.Graphics.DrawString(string.Format("Round {0}", (object) printingMatch.Round), font1, (Brush) solidBrush, x6, y1);
              ev.Graphics.DrawString(activeTournament.Name, font1, (Brush) solidBrush, x3, y1);
              ev.Graphics.DrawString(string.Format("Table {0}", (object) (activeTournament.TableOffset + printingMatch.Table)), font1, (Brush) solidBrush, x5, y1);
              ev.Graphics.DrawString(str1, font2, (Brush) solidBrush, new RectangleF(x1, y2, width3, height));
              ev.Graphics.DrawString(str4, font2, (Brush) solidBrush, new RectangleF(x4, y2, width6, height));
              ev.Graphics.DrawString(str3, font2, (Brush) solidBrush, new RectangleF(x2, y2, width5, height));
              ev.Graphics.DrawRectangle(pen1, new Rectangle((int) x1, (int) y3, (int) height, (int) height));
              sizeF = ev.Graphics.MeasureString(str8, font2);
              if ((double) sizeF.Width <= (double) width10)
              {
                ev.Graphics.DrawString(str8, font2, (Brush) solidBrush, new RectangleF(x7, y3, width10, height));
              }
              else
              {
                for (int index3 = 0; index3 < str8.Length; ++index3)
                {
                  string str10 = str8.Substring(0, str8.Length - index3) + "...";
                  sizeF = ev.Graphics.MeasureString(str10, font2);
                  if ((double) sizeF.Width < (double) width10)
                  {
                    ev.Graphics.DrawString(str10, font2, (Brush) solidBrush, new RectangleF(x7, y3, width10, height));
                    break;
                  }
                }
              }
              ev.Graphics.DrawRectangle(pen1, new Rectangle((int) num8, (int) num15, (int) num10, (int) num4));
              ev.Graphics.DrawRectangle(pen1, new Rectangle((int) num7, (int) y3, (int) height, (int) height));
              ev.Graphics.DrawRectangle(pen1, new Rectangle((int) x1, (int) y4, (int) height, (int) height));
              sizeF = ev.Graphics.MeasureString(str9, font2);
              if ((double) sizeF.Width <= (double) width10)
              {
                ev.Graphics.DrawString(str9, font2, (Brush) solidBrush, new RectangleF(x7, y4, width10, height));
              }
              else
              {
                for (int index3 = 0; index3 < str9.Length; ++index3)
                {
                  string str10 = str9.Substring(0, str9.Length - index3) + "...";
                  sizeF = ev.Graphics.MeasureString(str10, font2);
                  if ((double) sizeF.Width < (double) width10)
                  {
                    ev.Graphics.DrawString(str10, font2, (Brush) solidBrush, new RectangleF(x7, y4, width10, height));
                    break;
                  }
                }
              }
              ev.Graphics.DrawRectangle(pen1, new Rectangle((int) num8, (int) num16, (int) num10, (int) num4));
              ev.Graphics.DrawRectangle(pen1, new Rectangle((int) num7, (int) y4, (int) height, (int) height));
              ev.Graphics.DrawRectangle(pen1, new Rectangle((int) x1, (int) y5, (int) height, (int) height));
              ev.Graphics.DrawString(str7, font2, (Brush) solidBrush, new RectangleF(x7, y5, width9, height));
              if (Konami.Properties.Settings.Default.ResultSlips_JudgeSignature)
              {
                ev.Graphics.DrawString(str2, font2, (Brush) solidBrush, new RectangleF(x7, y6, width10, height));
                ev.Graphics.DrawRectangle(pen1, new Rectangle((int) num8, (int) num17, (int) num10, (int) num4));
              }
              ev.Graphics.DrawRectangle(pen1, new Rectangle((int) x1, (int) y7, (int) height, (int) height));
              ev.Graphics.DrawString(str6, font2, (Brush) solidBrush, new RectangleF(x7, y7, width8, height));
              ev.Graphics.DrawLine(pen1, (float) (int) num9, (float) (int) num18, (float) (int) num9 + num4, (float) (int) num18);
              ev.Graphics.DrawString(str5, font2, (Brush) solidBrush, new RectangleF(x8, y7, width7, height));
              ev.Graphics.DrawRectangle(pen1, new Rectangle((int) num7, (int) y7, (int) height, (int) height));
              Graphics graphics2 = ev.Graphics;
              Pen pen3 = pen1;
              marginBounds = ev.MarginBounds;
              int left3 = marginBounds.Left;
              int y1_1 = (int) num13;
              int x2_2 = (int) right;
              int y2_1 = (int) num13;
              graphics2.DrawLine(pen3, left3, y1_1, x2_2, y2_1);
            }
          }
        }
        ++this._currentPrintPage;
        ev.HasMorePages = this._currentPrintPage < num11;
      }
    }

    private void printDocStandings_PrintPage(object sender, PrintPageEventArgs ev)
    {
      float result = 12f;
      float.TryParse(Konami.Properties.Settings.Default.PrinterFontSize, out result);
      Font font1 = new Font(Konami.Properties.Settings.Default.PrinterFont, result, FontStyle.Bold, GraphicsUnit.Point);
      Font font2 = new Font(Konami.Properties.Settings.Default.PrinterFont, result, GraphicsUnit.Point);
      Font font3 = new Font(Konami.Properties.Settings.Default.PrinterFont, result, FontStyle.Italic, GraphicsUnit.Point);
      SolidBrush brush = new SolidBrush(Color.Black);
      float left = (float) ev.MarginBounds.Left;
      float top = (float) ev.MarginBounds.Top;
      float height = font2.GetHeight(ev.Graphics);
      int num1 = Convert.ToInt32((float) ev.MarginBounds.Height / height) - 5;
      PrintDocument printDocument = (PrintDocument) sender;
      float num2 = left + height * 3f;
      float x1 = left + (float) ev.MarginBounds.Width * 0.8f;
      float x2 = left + (float) ev.MarginBounds.Width * 0.9f;
      int val2 = (this._printingPlayerList.Count + num1 - 1) / num1;
      int num3 = 1;
      int num4 = val2;
      if (this.printDocStandings.PrinterSettings.PrintRange != PrintRange.AllPages)
      {
        num3 = Math.Max(this.printDocStandings.PrinterSettings.FromPage, 1);
        num4 = Math.Min(this.printDocStandings.PrinterSettings.ToPage, val2);
      }
      int num5 = this._currentPrintPage + num3 - 1;
      int num6 = num5 * num1;
      int num7 = num6 + num1;
      ev.Graphics.DrawString(printDocument.DocumentName, font1, (Brush) brush, left, top);
      float y = top + 2f * height;
      ev.Graphics.DrawString("Rank", font2, (Brush) brush, left, y);
      ev.Graphics.DrawString("Player", font2, (Brush) brush, num2, y);
      ev.Graphics.DrawString("Points", font2, (Brush) brush, x1, y);
      if (this.dlgPrintStandings.IncludeTiebreakers)
        ev.Graphics.DrawString("Tiebreaker", font2, (Brush) brush, x2, y);
      float num8 = y + height;
      for (int index = num6; index < num7; ++index)
      {
        if (this._printingPlayerList.Count > index)
        {
          ev.Graphics.DrawString(this._printingPlayerList[index].Rank.ToString(), font2, (Brush) brush, left, num8);
          string fullName = this._printingPlayerList[index].FullName;
          this.PrintStringToFit(!TournamentLibrary.BusinessLogic.Settings.ShowPlayerIds_ShowOnPrintouts ? (!this._printingPlayerList[index].IsActive ? string.Format("{0} ({1} - Round {2})", (object) this._printingPlayerList[index].FullName, (object) this._printingPlayerList[index].DropReason, (object) this._printingPlayerList[index].DropRound) : this._printingPlayerList[index].FullName) : (!this._printingPlayerList[index].IsActive ? string.Format("{0} ({1} - Round {2})", (object) this._printingPlayerList[index].FullNameWithId, (object) this._printingPlayerList[index].DropReason, (object) this._printingPlayerList[index].DropRound) : this._printingPlayerList[index].FullNameWithId), font2, brush, num2, num8, x1 - num2 - height, ev);
          ev.Graphics.DrawString(this._printingPlayerList[index].Tie1_Wins.ToString(), font2, (Brush) brush, x1, num8);
          if (this.dlgPrintStandings.IncludeTiebreakers)
            ev.Graphics.DrawString(this._printingPlayerList[index].Tie2_Points.ToString(), font2, (Brush) brush, x2, num8);
          num8 += height;
        }
      }
      string s = string.Format("Page {0} of {1}", (object) (num5 + 1), (object) val2);
      ev.Graphics.DrawString(s, font3, (Brush) brush, left, (float) ev.MarginBounds.Bottom - height);
      string shortTimeString = DateTime.Now.ToShortTimeString();
      ev.Graphics.DrawString(shortTimeString, font3, (Brush) brush, (float) ev.MarginBounds.Right - ev.Graphics.MeasureString(shortTimeString, font3).Width, (float) ev.MarginBounds.Bottom - height);
      ++this._currentPrintPage;
      if (this._currentPrintPage >= num4 - num3 + 1)
      {
        this._currentPrintPage = 0;
        ++this._currentPrintCopy;
      }
      ev.HasMorePages = this._currentPrintCopy < this._maxPrintCopy;
    }

    private void chkHideCompletedMatches_CheckedChanged(object sender, EventArgs e)
    {
      this._ToggleShowCompletedMatches();
    }

    private void chkStandingsIncludeDroppedPlayers_CheckedChanged(object sender, EventArgs e)
    {
      this.ShowPanel(MainForm.PanelTypes.Standings);
    }

    private void chkViewByPlayer_CheckedChanged(object sender, EventArgs e)
    {
      this._ShowPairings(this.RoundFromDropDownList);
    }

    private void ddlResultsEntryRound_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (!this.IsActiveTournament)
        return;
      if (this.RoundFromDropDownList == -1)
      {
        this._ShowPairings(this.ActiveTournament.CurrentRound);
      }
      else
      {
        if (this.RoundFromDropDownList != this.ActiveTournament.CurrentRound)
          this.chkHideCompletedMatches.Checked = false;
        this._ShowPairings(this.RoundFromDropDownList);
      }
    }

    private void ddlStandingsRound_SelectedIndexChanged(object sender, EventArgs e)
    {
      this._ShowStandings(this.ActiveTournament, this.ViewStandingsRound);
    }

    private void listEnrolledPlayers_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.listEnrolledPlayers.SelectedIndex < 0)
        return;
      Engine.SetCurrentPlayer(this.listEnrolledPlayers.SelectedItem);
      this._ShowCurrentPlayer();
    }

    private void listNameLookup_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.listNameLookup.SelectedIndex < 0)
        return;
      Engine.SetCurrentPlayer(this.listNameLookup.SelectedItem);
      this._ShowCurrentPlayer();
    }

    private void tabTournaments_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (((TabControl) sender).SelectedIndex < 0)
        return;
      string name = this.tabTournaments.SelectedTab.Name;
      MainForm.PanelTypes type;
      if (Engine.AllTournaments.HasId(name))
      {
        type = this._PanelsGetLastPanel(Engine.AllTournaments.FindById(name));
      }
      else
      {
        this.listEnrolledPlayers.Items.Clear();
        type = this.tabTournaments.TabCount != 1 ? this._PanelsGetVisiblePanel() : MainForm.PanelTypes.EnrollPlayer;
      }
      this.ShowPanel(type);
      this.UI_Cleanup();
    }

    private void addPlayersToGlobalListToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.UI_AddPlayersToGlobalList();
    }

    private void closeTournamentToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!this.IsActiveTournament)
        return;
      try
      {
        MainForm.PanelTypes lastPanel = this._PanelsGetLastPanel(this.ActiveTournament);
        this.TournamentClose(this.ActiveTournament);
        this.ShowPanel(lastPanel);
        this.UI_Cleanup();
        this.UI_UpdateResultsEntry();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
      }
    }

    private void doubleLossToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        this._ProcessResultEntryCommand('/');
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
      }
    }

    private void drawToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        this._ProcessResultEntryCommand('*');
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
      }
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void exportMatchesToCSVToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.UI_ExportTournamentToCSV();
    }

    private void exportPlayerlistToCSVToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!this.IsActiveTournament)
        return;
      ITournament activeTournament = this.ActiveTournament;
      this.dlgSaveFile.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
      this.dlgSaveFile.OverwritePrompt = true;
      this.dlgSaveFile.DefaultExt = "csv";
      this.dlgSaveFile.FileName = activeTournament.Name + " - Players";
      if (Directory.Exists(Konami.Properties.Settings.Default.DataStorageFolder))
        this.dlgSaveFile.InitialDirectory = Konami.Properties.Settings.Default.DataStorageFolder;
      if (this.dlgSaveFile.ShowDialog() != DialogResult.OK)
        return;
      activeTournament.ExportPlayersToCSV(this.dlgSaveFile.FileName);
    }

    private void finalizeTournamentToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.UI_FinalizeTournament();
    }

    private void findPlayersPairedTwiceThisRoundToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!this.IsActiveTournament)
        return;
      ITournament activeTournament = this.ActiveTournament;
      Engine.LogAction(activeTournament, UserAction.Find_Players_Paired_Twice);
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("Duplicates: ");
      ITournPlayerArray activePlayers = activeTournament.ActivePlayers;
      TournMatchArray tournMatchArray = new TournMatchArray();
      foreach (ITournPlayer tournPlayer in (IEnumerable<ITournPlayer>) activePlayers)
      {
        ITournMatchArray byRound = activeTournament.Matches.GetByPlayer(tournPlayer.ID).GetByRound(activeTournament.CurrentRound);
        if (byRound.Count > 1)
        {
          stringBuilder.AppendFormat("{0}: ", (object) tournPlayer.ToString());
          foreach (ITournMatch tournMatch in (IEnumerable<ITournMatch>) byRound)
            stringBuilder.AppendFormat("{0}, ", (object) (activeTournament.TableOffset + tournMatch.Table));
          stringBuilder.AppendLine("");
        }
      }
      int num = (int) MessageBox.Show(stringBuilder.ToString());
    }

    private void insertPlayer1NameWinsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        this._ProcessResultEntryCommand('-');
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
      }
    }

    private void insertPlayer2NameWinsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        this._ProcessResultEntryCommand('+');
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
      }
    }

    private void menuFileShowRecentLogEntriesToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int num = (int) new DialogLogViewer().ShowDialog();
    }

    private void menuItemAssignedSeatsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!this.IsActiveTournament)
        return;
      ITournament activeTournament = this.ActiveTournament;
      Engine.LogAction(activeTournament, UserAction.Assigned_Seats);
      int num = (int) new DialogAssignedSeats()
      {
        CurrentTournament = activeTournament
      }.ShowDialog();
      Engine.SaveTournamentToFile(activeTournament);
    }

    private void menuItemEnrollPlayersFromSeparateTournamentToolStripMenuItem_Click(
      object sender,
      EventArgs e)
    {
      if (!this.IsActiveTournament)
        return;
      ITournament activeTournament = this.ActiveTournament;
      Engine.LogAction(activeTournament, UserAction.Enroll_From_Another_Tournament);
      string[] strArray = this._OpenMultipleTournaments();
      if (strArray == null)
        return;
      int count = Engine.PlayerList.Count;
      int num1 = 0;
      foreach (string filename in strArray)
      {
        Tournament tournament = this._OpenTournament(filename);
        if (tournament != null && activeTournament != null)
        {
          this.WaitCursor(true);
          IPlayerArray players = this._AddPlayersAndStaff((ITournament) tournament);
          if (players.Count > 0)
            this._ShowAdditionalPlayers(players);
          foreach (ITournPlayer player in (IEnumerable<ITournPlayer>) tournament.Players)
          {
            if (activeTournament.EnrollPlayer((IPlayer) player))
              ++num1;
          }
        }
      }
      if (num1 > 0)
      {
        this._ShowEnrolledPlayers();
        this.UI_UpdateStatusBar();
        this.UI_UpdateToolbar();
      }
      Engine.SaveTournamentToFile(activeTournament);
      this.WaitCursor(false);
      int num2 = (int) MessageBox.Show(string.Format("{0} Players enrolled", (object) num1));
    }

    private void menuPairingsChangeMatchResultWizardToolStripMenuItem_Click(
      object sender,
      EventArgs e)
    {
      this.UI_WizardChangeMatchResult();
    }

    private void menuPairingsPrintPaireddownPlayersToolStripMenuItem_Click(
      object sender,
      EventArgs e)
    {
      if (!this.IsActiveTournament)
        return;
      ITournament activeTournament = this.ActiveTournament;
      if (this.GetPairedDownPlayers(activeTournament.CurrentRound).Count == 0)
      {
        int num = (int) MessageBox.Show("No players paired down this round");
      }
      else
      {
        this.dlgPrint.PrinterSettings = this.printDocPairings.PrinterSettings;
        if (this.dlgPrint.ShowDialog() != DialogResult.OK)
          return;
        this.printDocPairings.PrinterSettings = this.dlgPrint.PrinterSettings;
        this._PrintPairings(activeTournament, Engine.PrintPairingsAction.PairedDownPlayers, (int) this.dlgPrint.PrinterSettings.Copies, this.dlgPrint.PrinterSettings.PrinterName);
      }
    }

    private void menuPlayerUndropPlayerWizardToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.UI_WizardUndropPlayers();
    }

    private void menuTournamentbatchPrintingToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.UI_BatchPrinting();
    }

    private void menuTournImportMatchResultsFromASeparateFileToolStripMenuItem_Click(
      object sender,
      EventArgs e)
    {
      if (!this.IsActiveTournament)
        return;
      ITournament tourn = this._OpenTournamentDialog();
      ITournament activeTournament = this.ActiveTournament;
      if (tourn == null)
        return;
      if (tourn.ID != activeTournament.ID)
      {
        int num = (int) MessageBox.Show("Tournaments are not the same");
      }
      else
      {
        IPlayerArray players = this._AddPlayersAndStaff(tourn);
        if (players.Count > 0)
          this._ShowAdditionalPlayers(players);
        Engine.LogAction(activeTournament, UserAction.Merge_Round_Results, (object) activeTournament.Name);
        int currentRound = activeTournament.CurrentRound;
        foreach (TournMatch tournMatch in (IEnumerable<ITournMatch>) tourn.Matches.GetByRound(currentRound))
        {
          ITournMatch byRoundTable = activeTournament.Matches.GetByRoundTable(currentRound, tournMatch.Table);
          if (tournMatch.Completed && tournMatch.Players.Equals((object) byRoundTable.Players))
          {
            if (!byRoundTable.Completed)
              activeTournament.SubmitResult(tournMatch.Table, tournMatch.Status, tournMatch.Winner);
            foreach (ITournPlayer player in (IEnumerable<ITournPlayer>) tournMatch.Players)
            {
              if (!player.IsBye && player.DropRound == currentRound && activeTournament.Players.FindById(player.ID).IsActive)
                this._DropPlayer(activeTournament, player.ID, player.DropReason);
            }
          }
        }
        this._UpdateAfterMatchResult();
        this._RefreshPairingsGrid(currentRound);
      }
    }

    private void newToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        this.TournamentCreate();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
      }
    }

    private void newTournamentToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        this.TournamentCreate();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
      }
    }

    private void openToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        this.OpenTournament();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
      }
    }

    private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        this._ShowPreferencesDialog();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
      }
    }

    private void pairingsByPlayerToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.ShowPrintPairingsDialog(Engine.PrintPairingsAction.PrintByPlayer);
    }

    private void pairingsByTableToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.ShowPrintPairingsDialog(Engine.PrintPairingsAction.PrintByTable);
    }

    private void printBracketsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.ShowPrintPairingsDialog(Engine.PrintPairingsAction.PrintBrackets);
    }

    private void printPlayerListToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.ShowPrintPlayersDialog();
    }

    private void printPlayerNotesToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.ShowPrintPlayerNotesDialog();
    }

    private void printRandomTablesToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.ShowPrintPairingsDialog(Engine.PrintPairingsAction.RandomMatches);
    }

    private void printResultEntrySlipsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.ShowPrintResultSlipsDialog();
    }

    private void printStandingsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.PrintStandings();
    }

    private void printUnreportedMatchesToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.ShowPrintPairingsDialog(Engine.PrintPairingsAction.PrintUnreported);
    }

    private void recalcStandingsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!this.IsActiveTournament)
        return;
      ITournament activeTournament = this.ActiveTournament;
      Engine.LogAction(activeTournament, UserAction.Calculate_Ties);
      activeTournament.ClearTies();
      activeTournament.CalculateTies();
    }

    private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        if (!this.UI_SaveTournamentDialog())
          return;
        int num = (int) MessageBox.Show("Tournament Saved");
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
      }
    }

    private void saveToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        if (!this.UI_SaveTournamentDialog())
          return;
        int num = (int) MessageBox.Show("Tournament Saved");
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
      }
    }

    private void seatAllPlayersToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.PrintSeatAllPlayers();
    }

    private void setPairingsPrintoutRangesToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!this.IsActiveTournament)
        return;
      ITournament activeTournament = this.ActiveTournament;
      Engine.LogAction(activeTournament, UserAction.Set_Pairings_Printout_Ranges);
      DialogPairingsSplit dialogPairingsSplit = new DialogPairingsSplit();
      dialogPairingsSplit.SelectedTournament = activeTournament;
      dialogPairingsSplit.Splits = activeTournament.PrinterSplits;
      dialogPairingsSplit.SplitCount = activeTournament.PrinterSplits.SplitCount;
      int num = (int) dialogPairingsSplit.ShowDialog();
      activeTournament.PrinterSplits.SplitCount = dialogPairingsSplit.SplitCount;
    }

    private void subMenuGlobalPlayer_changePlayerCOSSYIDToolStripMenuItem_Click(
      object sender,
      EventArgs e)
    {
      if (this._subMenuSelectedControl != this.listEnrolledPlayers && this._subMenuSelectedControl != this.listNameLookup)
        return;
      ListBox menuSelectedControl = (ListBox) this._subMenuSelectedControl;
      int selectedIndex = menuSelectedControl.SelectedIndex;
      if (selectedIndex < 0)
        return;
      IPlayer selectedItem = (IPlayer) menuSelectedControl.SelectedItem;
      if (selectedItem != null)
        this.ChangePlayerID(selectedItem);
      menuSelectedControl.TopIndex = selectedIndex;
      menuSelectedControl.SelectedIndex = selectedIndex;
    }

    private void subMenuGlobalPlayer_changePlayerNameToolStripMenuItem_Click(
      object sender,
      EventArgs e)
    {
      if (!this.IsActiveTournament)
        return;
      ITournament activeTournament = this.ActiveTournament;
      if (this._subMenuSelectedControl != this.listEnrolledPlayers && this._subMenuSelectedControl != this.listNameLookup)
        return;
      ListBox menuSelectedControl = (ListBox) this._subMenuSelectedControl;
      int num = menuSelectedControl.SelectedIndex;
      if (num < 0)
        return;
      IPlayer selectedItem = (IPlayer) menuSelectedControl.SelectedItem;
      if (selectedItem != null)
      {
        if (this._subMenuSelectedControl == this.listEnrolledPlayers)
        {
          this.ChangePlayerName(selectedItem.ID, activeTournament.Players.Downgrade());
          ITournPlayer byId = activeTournament.Players.FindById(selectedItem.ID);
          activeTournament.Players.SortByLastname();
          num = menuSelectedControl.Items.IndexOf((object) byId);
        }
        else if (this._subMenuSelectedControl == this.listNameLookup)
        {
          this.ChangePlayerName(selectedItem.ID, Engine.PlayerList);
          IPlayer byId = Engine.PlayerList.FindById(selectedItem.ID);
          Engine.PlayerList.SortByLastname();
          num = menuSelectedControl.Items.IndexOf((object) byId);
        }
      }
      if (num >= 0 && num < menuSelectedControl.Items.Count)
      {
        menuSelectedControl.TopIndex = num;
        menuSelectedControl.SelectedIndex = num;
      }
      this._ClearPlayerTextBoxes();
    }

    private void subMenuGlobalPlayer_deletePlayerToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this._subMenuSelectedControl != this.listNameLookup || this.listNameLookup.SelectedIndex < 0)
        return;
      IPlayer selectedItem = (IPlayer) this.listNameLookup.SelectedItem;
      if (selectedItem == null || MessageBox.Show(string.Format("Delete {0} ({1}) from the Global List?", (object) selectedItem.FullName, (object) selectedItem.IDFormatted), "Delete Global Player", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
        return;
      this._DeletePlayer(selectedItem);
    }

    private void subMenuGlobalPlayer_viewMatchHistoryToolStripMenuItem_Click(
      object sender,
      EventArgs e)
    {
      if (!this.IsActiveTournament || this._subMenuSelectedControl != this.listEnrolledPlayers)
        return;
      ListBox menuSelectedControl = (ListBox) this._subMenuSelectedControl;
      if (menuSelectedControl.SelectedIndex < 0)
        return;
      ITournPlayer selectedItem = (ITournPlayer) menuSelectedControl.SelectedItem;
      if (selectedItem == null)
        return;
      int num = (int) new DialogMatchHistory()
      {
        currentTournament = this.ActiveTournament,
        currentPlayer = selectedItem
      }.ShowDialog();
    }

    private void subMenuGlobalPlayer_viewPLayersPenaltiesToolStripMenuItem_Click(
      object sender,
      EventArgs e)
    {
      if (!this.IsActiveTournament || this._subMenuSelectedControl != this.listEnrolledPlayers)
        return;
      ListBox menuSelectedControl = (ListBox) this._subMenuSelectedControl;
      int selectedIndex = menuSelectedControl.SelectedIndex;
      if (selectedIndex < 0)
        return;
      IPlayer selectedItem = (IPlayer) menuSelectedControl.SelectedItem;
      if (selectedItem != null)
        this.ShowPenalties(selectedItem);
      menuSelectedControl.SelectedIndex = selectedIndex;
    }

    private void tournamentCutToPlayoffsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.PairPlayoffs();
    }

    private void tournamentSetStartingTableToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.ChangeStartingTable();
    }

    private void tournamentViewPairingsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.ShowPanel(MainForm.PanelTypes.Matches);
    }

    private void tournamentViewPlayerMatchHistoryToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!this.IsActiveTournament)
      {
        int num1 = (int) MessageBox.Show("No tournament selected");
      }
      else
      {
        int num2 = (int) new DialogMatchHistory()
        {
          currentTournament = this.ActiveTournament,
          currentPlayer = ((ITournPlayer) null)
        }.ShowDialog();
      }
    }

    private void tournamentViewPlayersToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.ShowPanel(MainForm.PanelTypes.EnrollPlayer);
    }

    private void tournamentViewStandingsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.ShowPanel(MainForm.PanelTypes.Standings);
    }

    private void updateSettingsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.TournamentUpdate();
    }

    private void verifyRepeatMatchesToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!this.IsActiveTournament)
        return;
      ITournament activeTournament = this.ActiveTournament;
      if (activeTournament.CurrentRound < 2)
        return;
      TournMatchArray tournMatchArray = new TournMatchArray();
      foreach (ITournMatch match in (IEnumerable<ITournMatch>) activeTournament.Matches.GetByRound(activeTournament.CurrentRound))
      {
        if (activeTournament.HavePlayed(match.Players, activeTournament.CurrentRound - 1))
          tournMatchArray.AddMatch(match);
      }
      if (tournMatchArray.Count == 0)
      {
        int num1 = (int) MessageBox.Show("No matches this round have players who have played each other previously");
      }
      else
      {
        string text = "These players have played before:\r\n";
        foreach (ITournMatch tournMatch in (List<ITournMatch>) tournMatchArray)
          text += string.Format("Table {0}: {1} vs {2}\r\n", (object) (activeTournament.TableOffset + tournMatch.Table), (object) tournMatch.Players[0], (object) tournMatch.Players[1]);
        int num2 = (int) MessageBox.Show(text);
      }
    }

    private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      int num = (int) new DialogAbout().ShowDialog();
    }

    private void btnAllPlayerSearch_Click(object sender, EventArgs e)
    {
      this._PerformPlayerSearch();
    }

    private void btnAllPlayersShowAll_Click(object sender, EventArgs e)
    {
      this._ShowGlobalPlayers();
    }

    private void btnClearPlayer_Click(object sender, EventArgs e)
    {
      this._ClearPlayerTextBoxes();
    }

    private void btnDropPlayer_Click(object sender, EventArgs e)
    {
      this.DropPlayer();
    }

    private void btnEnrollPlayer_Click(object sender, EventArgs e)
    {
      this._EnrollSelectedPlayer();
    }

    private void btnOpenDuelingMinus_Click(object sender, EventArgs e)
    {
      this.AddSubtractOpenDuelingPoint(true);
    }

    private void btnOpenDuelingPlus_Click(object sender, EventArgs e)
    {
      this.AddSubtractOpenDuelingPoint(false);
    }

    private void btnTempID_Click(object sender, EventArgs e)
    {
      if (!this.IsActiveTournament)
        return;
      this._ClearPlayerTextBoxes();
      this.UI_CreateTempCossyID();
    }

    private void btnToolStrip_CancelRound_Click(object sender, EventArgs e)
    {
      this.UI_CancelRound();
    }

    private void btnToolStrip_PairPlayoffs_Click(object sender, EventArgs e)
    {
      this.PairPlayoffs();
    }

    private void btnToolStrip_PairRound_Click(object sender, EventArgs e)
    {
      this._PairNextRound(this.ActiveTournament, false);
    }

    private void btnToolStrip_PrintBrackets_Click(object sender, EventArgs e)
    {
      this.ShowPrintPairingsDialog(Engine.PrintPairingsAction.PrintBrackets);
    }

    private void btnToolStrip_PrintPairings_Click(object sender, EventArgs e)
    {
      if (this._currentPairingsPrint != Engine.PrintPairingsAction.PrintByTable || this._currentPairingsPrint != Engine.PrintPairingsAction.PrintByPlayer)
        this._currentPairingsPrint = Engine.PrintPairingsAction.PrintByPlayer;
      this.ShowPrintPairingsDialog(this._currentPairingsPrint);
    }

    private void btnToolStrip_PrintPlayers_Click(object sender, EventArgs e)
    {
      this.ShowPrintPlayersDialog();
    }

    private void btnToolStrip_PrintResultSlips_Click(object sender, EventArgs e)
    {
      this.ShowPrintResultSlipsDialog();
    }

    private void btnToolStrip_PrintStandings_Click(object sender, EventArgs e)
    {
      this.PrintStandings();
    }

    private void btnToolStrip_RepairRound_Click(object sender, EventArgs e)
    {
      this._PairNextRound(this.ActiveTournament, true);
    }

    private void btnToolStrip_ViewPairings_Click(object sender, EventArgs e)
    {
      this.ShowPanel(MainForm.PanelTypes.Matches);
      this.UI_MatchResultsTableHightlight();
    }

    private void btnToolStrip_ViewPlayers_Click(object sender, EventArgs e)
    {
      this.ShowPanel(MainForm.PanelTypes.EnrollPlayer);
    }

    private void btnToolStrip_ViewStandings_Click(object sender, EventArgs e)
    {
      this.ShowPanel(MainForm.PanelTypes.Standings);
    }

    private void chkResultsPlayer1Drops_Click(object sender, EventArgs e)
    {
      this.DropBoxChecked(true);
    }

    private void chkResultsPlayer2Drops_Click(object sender, EventArgs e)
    {
      this.DropBoxChecked(false);
    }

    private void listEnrolledPlayers_DoubleClick(object sender, EventArgs e)
    {
      try
      {
        this.DropPlayer();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(string.Format("Error in listEnrolledPlayers_DoubleClick: {0}", (object) ex.Message));
      }
    }

    private void listNameLookup_DoubleClick(object sender, EventArgs e)
    {
      try
      {
        if (this.listNameLookup.SelectedIndex < 0)
          return;
        Engine.SetCurrentPlayer(this.listNameLookup.SelectedItem);
        this._EnrollSelectedPlayer();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(string.Format("Error in listNameLookup_DoubleClick: {0}", (object) ex.Message));
      }
    }

    private void manualPairingsToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      this.ManualPairings();
    }

    private void menuExportGlobalPlayerlisttoCSV_Click(object sender, EventArgs e)
    {
      this.UI_ExportGlobalListToCSV();
    }

    private void menuItemChangePlayerID_Click(object sender, EventArgs e)
    {
      DialogChangePlayerId dialogChangePlayerId = new DialogChangePlayerId();
      if (dialogChangePlayerId.ShowDialog() != DialogResult.OK)
        return;
      this._ChangePlayerID(dialogChangePlayerId.OldPlayerID, dialogChangePlayerId.NewPlayerID);
    }

    private void menuItemChangePlayerName_Click(object sender, EventArgs e)
    {
      this.ChangePlayerName();
    }

    private void menuItemDropPlayer_Click(object sender, EventArgs e)
    {
      ITournament activeTournament = this.ActiveTournament;
      if (activeTournament == null)
        return;
      DialogSelectPerson dialogSelectPerson = new DialogSelectPerson();
      dialogSelectPerson.AllowNewPlayers = false;
      dialogSelectPerson.Title = "Drop Player";
      dialogSelectPerson.PlayerList = activeTournament.ActivePlayers;
      if (dialogSelectPerson.ShowDialog() != DialogResult.OK)
        return;
      ITournPlayer byId = activeTournament.Players.FindById(dialogSelectPerson.NewPlayer.ID);
      if (byId == null)
        return;
      this._DropPlayer(activeTournament, byId.ID, CutType.Drop);
      this.UI_Cleanup();
      this.UI_UpdateResultsEntry();
      this.UI_UpdateMatchRowPlayer(byId);
    }

    private void menuItemPlayerNotes_Click(object sender, EventArgs e)
    {
      this.ShowPenalties();
    }

    private void menuItemReEnrollPlayer_Click(object sender, EventArgs e)
    {
      ITournament activeTournament = this.ActiveTournament;
      if (activeTournament == null)
        return;
      DialogSelectPerson dialogSelectPerson = new DialogSelectPerson();
      dialogSelectPerson.Title = "Re-Enroll Player";
      dialogSelectPerson.AllowNewPlayers = false;
      TournPlayerArray tournPlayerArray = new TournPlayerArray();
      foreach (TournPlayer player in (IEnumerable<ITournPlayer>) activeTournament.Players)
      {
        if (!player.IsActive)
          tournPlayerArray.AddPlayer((ITournPlayer) player);
      }
      dialogSelectPerson.PlayerList = (ITournPlayerArray) tournPlayerArray;
      if (dialogSelectPerson.ShowDialog() != DialogResult.OK)
        return;
      ITournPlayer byId = activeTournament.Players.FindById(dialogSelectPerson.NewPlayer.ID);
      if (byId == null)
        return;
      this._DropPlayer(activeTournament, byId.ID, CutType.Active);
      this.UI_Cleanup();
      this._ShowPairings(this.RoundFromDropDownList);
      this.UI_UpdateMatchRowPlayer(byId);
    }

    private void menuItemSelectTournament_Click(object sender, EventArgs e)
    {
      string str = ((ToolStripItem) sender).Tag.ToString();
      if (!this.tabTournaments.TabPages.ContainsKey(str))
        return;
      this.tabTournaments.SelectTab(str);
      this.UI_Cleanup();
      this.UI_UpdateResultsEntry();
    }

    private void pairNextRoundToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      this._PairNextRound(this.ActiveTournament, false);
    }

    private void radioResultsDoubleLoss_Click(object sender, EventArgs e)
    {
      this._ProcessResultEntryCommand('/');
      this.UI_MatchResultsTableHightlight();
    }

    private void radioResultsDraw_Click(object sender, EventArgs e)
    {
      this._ProcessResultEntryCommand('*');
      this.UI_MatchResultsTableHightlight();
    }

    private void radioResultsPlayer1_Click(object sender, EventArgs e)
    {
      this._ProcessResultEntryCommand('-');
      this.UI_MatchResultsTableHightlight();
    }

    private void radioResultsPlayer2_Click(object sender, EventArgs e)
    {
      this._ProcessResultEntryCommand('+');
      this.UI_MatchResultsTableHightlight();
    }

    private void radioResultsUnreported_Click(object sender, EventArgs e)
    {
      this._ProcessResultEntryCommand('$');
      this.UI_MatchResultsTableHightlight();
    }

    private void toolStripButton_BatchPrint_Click(object sender, EventArgs e)
    {
      this.UI_BatchPrinting();
    }

    private void toolStripButton_WizardChangeResult_Click(object sender, EventArgs e)
    {
      this.UI_WizardChangeMatchResult();
    }

    private void toolStripButton_WizardUndropPlayer_Click(object sender, EventArgs e)
    {
      this.UI_WizardUndropPlayers();
    }

    private int ChangePlayerName(long targetPlayerId, IPlayerArray DisplayedPlayerList)
    {
      int num1 = 0;
      DialogChangePlayerName changePlayerName = new DialogChangePlayerName();
      if (targetPlayerId != Player.BYE_ID)
        changePlayerName.SelectedPlayerId = targetPlayerId;
      changePlayerName.DisplayedPlayerList = DisplayedPlayerList;
      int num2 = (int) changePlayerName.ShowDialog();
      if (changePlayerName.ChangedPlayers.Count > 0)
      {
        foreach (IPlayer changedPlayer in (List<IPlayer>) changePlayerName.ChangedPlayers)
          num1 = this._ChangePlayerName(changedPlayer.ID, changedPlayer.FirstName, changedPlayer.LastName);
      }
      this._ShowEnrolledPlayers();
      this.ddlStandingsRound.SelectedIndex = -1;
      return num1;
    }

    private ITournMatch UpdateCurrentMatch()
    {
      Engine.CurrentTournMatch = (ITournMatch) null;
      if (!this.IsActiveTournament)
        return (ITournMatch) null;
      ITournMatch match = this.ActiveTournament.GetMatch(this.RoundFromDropDownList, this.TableFromResultsEntry);
      if (match == null)
        return (ITournMatch) null;
      Engine.CurrentTournMatch = match;
      return match;
    }

    private ITournMatchArray GetPairedDownPlayers(int round)
    {
      return !this.IsActiveTournament ? (ITournMatchArray) new TournMatchArray() : this.ActiveTournament.Matches.GetPairedDown(round);
    }

    private long ParsePlayerId(string sId)
    {
      long result = Player.BYE_ID;
      if (long.TryParse(sId, out result))
        return result;
      return this._PlayerIdEntered ? (long) Common.RandomGenerator.Next(1000000, 99999999) : Player.BYE_ID;
    }

    private static string FormatNameWithWins(ITournPlayer player)
    {
      string str1 = "point";
      string str2 = "points";
      string empty = string.Empty;
      return !player.IsBye ? (!Konami.Properties.Settings.Default.ShowPlayerIds_ShowOnPrintouts ? string.Format("{0} ({1} {2})", (object) player.FullName, (object) player.Tie1_Wins, player.Tie1_Wins == 1 ? (object) str1 : (object) str2) : string.Format("{0} ({1} {2})", (object) player.FullNameWithId, (object) player.Tie1_Wins, player.Tie1_Wins == 1 ? (object) str1 : (object) str2)) : player.ToString();
    }

    private TabPage GetTabByTournamentID(string id)
    {
      int index = this.tabTournaments.TabPages.IndexOfKey(id);
      return index < 0 ? (TabPage) null : this.tabTournaments.TabPages[index];
    }

    private void AddSubtractOpenDuelingPoint(bool subtractPoint)
    {
      if (!this.IsActiveTournament)
        return;
      ITournament activeTournament = this.ActiveTournament;
      int points = subtractPoint ? -1 : 1;
      if (Engine.CurrentPlayerSelected)
      {
        if (activeTournament.Players.FindById(Engine.CurrentPlayer.ID) == null)
          this._EnrollOpenDuelingPlayer();
        this._AddOpenDuelingPoint(Engine.CurrentPlayer, points);
        this._ShowStandings(activeTournament);
        this._ClearOpenDuelingPlayer();
      }
      else if (this.txtOpenDuelingLastName.Text.Length > 0 && this.txtOpenDuelingFirstname.Text.Length > 0)
      {
        this._EnrollOpenDuelingPlayer();
        this._AddOpenDuelingPoint(Engine.CurrentPlayer, points);
        this._ShowStandings(activeTournament);
        this._ClearOpenDuelingPlayer();
      }
      else if (this.txtOpenDuelingFirstname.Text.Length > 0)
        this.txtOpenDuelingLastName.Focus();
      else
        this.txtOpenDuelingLastName.Focus();
    }

    private void AddTournamentToOpenMenu(ITournament t)
    {
      int index1 = this.menuItemCurrentTournamentsToolStripMenuItem.DropDownItems.Count;
      for (int index2 = this.menuItemCurrentTournamentsToolStripMenuItem.DropDownItems.Count - 1; index2 >= 0; --index2)
      {
        string id = this.menuItemCurrentTournamentsToolStripMenuItem.DropDownItems[index2].Tag.ToString();
        ITournament byId = Engine.AllTournaments.FindById(id);
        if (byId != null && string.Compare(t.Name, byId.Name, false) < 0)
          index1 = index2;
      }
      ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
      toolStripMenuItem.Text = t.Name;
      toolStripMenuItem.Click += new EventHandler(this.menuItemSelectTournament_Click);
      toolStripMenuItem.Tag = (object) t.ID;
      this.menuItemCurrentTournamentsToolStripMenuItem.DropDownItems.Insert(index1, (ToolStripItem) toolStripMenuItem);
    }

    private void ChangePlayerID(IPlayer p)
    {
      DialogChangePlayerId dialogChangePlayerId = new DialogChangePlayerId();
      dialogChangePlayerId.OldPlayerID = p.ID;
      if (dialogChangePlayerId.ShowDialog() != DialogResult.OK)
        return;
      this._ChangePlayerID(dialogChangePlayerId.OldPlayerID, dialogChangePlayerId.NewPlayerID);
    }

    private void ChangePlayerName()
    {
      this.ChangePlayerName(Player.BYE_ID, Engine.PlayerList);
    }

    private void ChangeStartingTable()
    {
      if (!this.IsActiveTournament)
      {
        int num1 = (int) MessageBox.Show("No Tournament Selected");
      }
      else
      {
        ITournament activeTournament = this.ActiveTournament;
        int result = activeTournament.TableOffset + 1;
        DialogSimpleTextBox dialogSimpleTextBox = new DialogSimpleTextBox();
        dialogSimpleTextBox.Bind("Set Starting Table", "Enter the first table of the tournament.  This change will take effect immediately", result.ToString());
        if (dialogSimpleTextBox.ShowDialog() != DialogResult.OK)
          return;
        if (int.TryParse(dialogSimpleTextBox.Input, out result))
        {
          activeTournament.TableOffset = result - 1;
        }
        else
        {
          int num2 = (int) MessageBox.Show("Unable to read table number, please try again");
        }
      }
    }

    private void CopySettings()
    {
      TournamentLibrary.BusinessLogic.Settings.DataStorageFolder = Konami.Properties.Settings.Default.DataStorageFolder;
      TournamentLibrary.BusinessLogic.Settings.PrinterFont = Konami.Properties.Settings.Default.PrinterFont;
      TournamentLibrary.BusinessLogic.Settings.PrinterFontSize = Konami.Properties.Settings.Default.PrinterFontSize;
      TournamentLibrary.BusinessLogic.Settings.ShowPlayerIds_ShowOnScreen = Konami.Properties.Settings.Default.ShowPlayerIds_DisplayOnScreen;
      TournamentLibrary.BusinessLogic.Settings.ShowPlayerIds_ShowOnPrintouts = Konami.Properties.Settings.Default.ShowPlayerIds_ShowOnPrintouts;
      TournamentLibrary.BusinessLogic.Settings.ToolBar_IconsAndText = Konami.Properties.Settings.Default.ToolBar_IconsAndText;
      TournamentLibrary.BusinessLogic.Settings.ToolBar_IconsOnly = Konami.Properties.Settings.Default.ToolBar_IconsOnly;
      TournamentLibrary.BusinessLogic.Settings.ToolBar_TextOnly = Konami.Properties.Settings.Default.ToolBar_TextOnly;
      TournamentLibrary.BusinessLogic.Settings.ToolBarButtonSize = Konami.Properties.Settings.Default.ToolBarButtonSize;
    }

    private void DropBoxChecked(bool player1)
    {
      if (!this.IsActiveTournament || Engine.CurrentTournMatch == null || Engine.CurrentTournMatch.Players.Count <= 0)
        return;
      ITournPlayer player = Engine.CurrentTournMatch.Players[0];
      CutType dropReason = this.chkResultsPlayer1Drops.Checked ? CutType.Drop : CutType.Active;
      if (!player1)
      {
        player = Engine.CurrentTournMatch.Players[1];
        dropReason = this.chkResultsPlayer2Drops.Checked ? CutType.Drop : CutType.Active;
      }
      this._DropPlayer(this.ActiveTournament, player.ID, dropReason);
      this.UI_Cleanup();
      this.UI_UpdateMatchRowResult(Engine.CurrentTournMatch);
      this.UI_MatchResultsTableHightlight();
    }

    private void DropPlayer()
    {
      if (!Engine.CurrentPlayerSelected || !this.IsActiveTournament)
        return;
      ITournament activeTournament = this.ActiveTournament;
      if (MessageBox.Show(string.Format("Drop Player {0}?", (object) Engine.CurrentPlayer.ToString()), "Drop Player", MessageBoxButtons.YesNoCancel) != DialogResult.Yes)
        return;
      ITournPlayer byId = activeTournament.Players.FindById(Engine.CurrentPlayer.ID);
      this._DropPlayer(activeTournament, byId.ID, CutType.Drop);
      this.UI_Cleanup();
      this.UI_UpdateMatchRowPlayer(byId);
    }

    private void KeyPressPlayerEnroll(
      KeyEventArgs e,
      TextBox txtFocused,
      TextBox txtOther,
      bool firstNameFocused)
    {
      if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Return)
      {
        if (Engine.CurrentPlayerSelected)
          this._EnrollSelectedPlayer();
        else if (this.txtCurrentPlayerLastName.Text.Length > 0 && this.txtCurrentPlayerFirstName.Text.Length > 0 && this._PlayerIdEntered)
          this._EnrollSelectedPlayer();
        else if (this.txtCurrentPlayerFirstName.Text.Length == 0)
          this.txtCurrentPlayerFirstName.Focus();
        else if (this.txtCurrentPlayerLastName.Text.Length == 0)
          this.txtCurrentPlayerLastName.Focus();
        else
          this.txtCurrentPlayerID.Focus();
        e.Handled = true;
      }
      else if (e.KeyCode == Keys.Down)
      {
        if (this.listNameLookup.SelectedIndex < this.listNameLookup.Items.Count)
        {
          ++this.listNameLookup.TopIndex;
          ++this.listNameLookup.SelectedIndex;
          Engine.CurrentPlayer = (IPlayer) this.listNameLookup.SelectedItem;
          this._ShowCurrentPlayer();
        }
        e.Handled = true;
        txtFocused.SelectAll();
        txtOther.SelectAll();
        this.txtCurrentPlayerID.SelectAll();
      }
      else if (e.KeyCode == Keys.Up)
      {
        if (this.listNameLookup.SelectedIndex > 0)
        {
          this.listNameLookup.TopIndex = Math.Max(0, this.listNameLookup.TopIndex - 1);
          this.listNameLookup.SelectedIndex = Math.Max(0, this.listNameLookup.SelectedIndex - 1);
          Engine.CurrentPlayer = (IPlayer) this.listNameLookup.SelectedItem;
          this._ShowCurrentPlayer();
        }
        e.Handled = true;
        txtFocused.SelectAll();
        txtOther.SelectAll();
        this.txtCurrentPlayerID.SelectAll();
      }
      else if (Utility.IsPrintableCharacter(e.KeyCode))
        ;
    }

    private void listEnrolledPlayers_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Right)
        return;
      int num = this.listEnrolledPlayers.IndexFromPoint(e.Location);
      if (num == -1)
        return;
      this._subMenuSelectedControl = (Control) this.listEnrolledPlayers;
      this.listEnrolledPlayers.SelectedIndex = num;
      ITournPlayer tournPlayer = (ITournPlayer) this.listEnrolledPlayers.Items[this.listEnrolledPlayers.SelectedIndex];
      this.subMenuEditGlobalPlayer.Items[this.subMenuGlobalPlayer_changePlayerNameToolStripMenuItem.Name].Text = string.Format("Change Player Name ({0})", (object) tournPlayer.FullName);
      this.subMenuEditGlobalPlayer.Items[this.subMenuGlobalPlayer_changePlayerCOSSYIDToolStripMenuItem.Name].Text = string.Format("Change Player COSSY ID ({0})", (object) tournPlayer.IDFormatted);
      this.subMenuEditGlobalPlayer.Items[this.subMenuGlobalPlayer_deletePlayerToolStripMenuItem.Name].Enabled = false;
      this.subMenuEditGlobalPlayer.Items[this.subMenuGlobalPlayer_viewMatchHistoryToolStripMenuItem.Name].Enabled = true;
      this.subMenuEditGlobalPlayer.Items[this.subMenuGlobalPlayer_viewPLayersPenaltiesToolStripMenuItem.Name].Enabled = true;
      this.subMenuEditGlobalPlayer.Show((Control) this.listEnrolledPlayers, e.Location);
    }

    private void listNameLookup_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Right)
        return;
      int num = this.listNameLookup.IndexFromPoint(e.Location);
      if (num == -1)
        return;
      this._subMenuSelectedControl = (Control) this.listNameLookup;
      this.listNameLookup.SelectedIndex = num;
      if (this.listNameLookup.Items.Count <= 0)
        return;
      IPlayer player = (IPlayer) this.listNameLookup.Items[this.listNameLookup.SelectedIndex];
      this.subMenuEditGlobalPlayer.Items[this.subMenuGlobalPlayer_changePlayerNameToolStripMenuItem.Name].Text = string.Format("Change Player Name ({0})", (object) player.FullName);
      this.subMenuEditGlobalPlayer.Items[this.subMenuGlobalPlayer_changePlayerCOSSYIDToolStripMenuItem.Name].Text = string.Format("Change Player COSSY ID ({0})", (object) player.IDFormatted);
      this.subMenuEditGlobalPlayer.Items[this.subMenuGlobalPlayer_deletePlayerToolStripMenuItem.Name].Enabled = true;
      this.subMenuEditGlobalPlayer.Items[this.subMenuGlobalPlayer_viewMatchHistoryToolStripMenuItem.Name].Enabled = false;
      this.subMenuEditGlobalPlayer.Items[this.subMenuGlobalPlayer_viewPLayersPenaltiesToolStripMenuItem.Name].Enabled = false;
      this.subMenuEditGlobalPlayer.Show((Control) this.listNameLookup, e.Location);
    }

    private void ManualPairings()
    {
      if (!this.IsActiveTournament)
        return;
      ITournament activeTournament = this.ActiveTournament;
      ManualPairings manualPairings = new ManualPairings();
      manualPairings.Tournament = activeTournament;
      manualPairings.Round = this.RoundFromDropDownList;
      manualPairings.Tournament.CalculateTies(manualPairings.Round);
      if (manualPairings.ShowDialog() != DialogResult.OK)
        return;
      activeTournament.Matches.DeleteRound(this.RoundFromDropDownList);
      activeTournament.Matches.Append(manualPairings.Matches);
      this._ShowPairings(this.RoundFromDropDownList);
      Engine.SaveTournamentToFile(activeTournament);
      if (manualPairings.NewMatches.Count <= 0 || MessageBox.Show("Print new match result slips?", "Match Slips", MessageBoxButtons.YesNo) != DialogResult.Yes)
        return;
      this._currentPrintPage = 0;
      this._printingMatches = (ITournMatchArray) manualPairings.NewMatches;
      this.printDocResultSlips.PrinterSettings = this.dlgPrint.PrinterSettings;
      this.printDocResultSlips.DocumentName = activeTournament.Name + " Result Slips";
      this.printDocResultSlips.Print();
    }

    private void OnIdle(object sender, EventArgs e)
    {
      ITournament activeTournament = this.ActiveTournament;
      bool flag1 = this.IsActiveTournament && this.ActiveTournament.Format != TournamentStyle.OpenDueling;
      bool flag2 = this.IsActiveTournament && activeTournament.Players.Count > 0 && activeTournament.Matches.UnreportedMatches.Count == 0;
      bool flag3 = activeTournament != null && activeTournament.Players.Count > 0 && activeTournament.CurrentRound == 0;
      bool flag4 = activeTournament != null && activeTournament.CurrentRound > 0;
      bool flag5 = activeTournament != null && activeTournament.Players.Count > 0;
      bool flag6 = this.IsActiveTournament && activeTournament.Players.TempPlayerCount != 0;
      bool flag7 = activeTournament != null && (activeTournament.CurrentRound > 1 || flag2 || activeTournament.PairingStructure == TournamentPairingStructure.OpenDueling);
      bool flag8 = activeTournament != null && (activeTournament.IsPlayoffs || activeTournament.PairingStructure == TournamentPairingStructure.SingleElimination);
      bool flag9 = activeTournament != null && activeTournament.Finalized;
      bool flag10 = activeTournament != null && !activeTournament.Finalized;
      bool flag11 = this.IsActiveTournament && activeTournament.ActivePlayers.Count > 1;
      this.fileSaveTournamentToolStripMenuItem.Enabled = this.IsActiveTournament;
      this.fileCloseTournamentToolStripMenuItem.Enabled = this.IsActiveTournament;
      this.fileOpenTournamentToolStripMenuItem.Enabled = true;
      this.menuItemCurrentTournamentsToolStripMenuItem.Enabled = this.IsActiveTournament;
      this.menuItemAssignedSeatsToolStripMenuItem.Enabled = this.IsActiveTournament && flag5;
      this.menuItemPlayerNotes.Enabled = this.IsActiveTournament && flag5;
      this.menuItemDropPlayer.Enabled = this.IsActiveTournament && flag5;
      this.menuItemReEnrollPlayer.Enabled = this.IsActiveTournament && flag5;
      this.exportPlayerlistToCSVToolStripMenuItem.Enabled = this.IsActiveTournament && flag5;
      this.exportMatchesToCSVToolStripMenuItem.Enabled = this.IsActiveTournament && flag4;
      this.menuItemEnrollPlayersFromSeparateTournamentToolStripMenuItem.Enabled = this.IsActiveTournament;
      this.tournamentViewPlayersToolStripMenuItem.Enabled = flag5;
      this.tournamentViewPairingsToolStripMenuItem.Enabled = flag4;
      this.tournamentViewStandingsToolStripMenuItem.Enabled = flag7;
      this.tournamentManualPairingsToolStripMenuItem.Enabled = flag4;
      this.tournamentSetStartingTableToolStripMenuItem.Enabled = this.IsActiveTournament;
      this.tournamentUpdateSettingsToolStripMenuItem.Enabled = this.IsActiveTournament;
      this.tournamentViewPlayerMatchHistoryToolStripMenuItem.Enabled = flag4;
      this.printPlayerListToolStripMenuItem.Enabled = flag5;
      this.printPairingsByPlayerToolStripMenuItem.Enabled = flag4;
      this.printPairingsByTableToolStripMenuItem.Enabled = flag4;
      this.printBracketsToolStripMenuItem.Enabled = flag8;
      this.printResultEntrySlipsToolStripMenuItem.Enabled = flag4;
      this.printStandingsToolStripMenuItem.Enabled = flag7;
      this.printUnreportedMatchesToolStripMenuItem.Enabled = flag4 && !flag2;
      this.printRandomTablesToolStripMenuItem.Enabled = flag4;
      this.printPlayerNotesToolStripMenuItem.Enabled = this.IsActiveTournament && activeTournament.Penalties.Count > 0;
      this.finalizeTournamentToolStripMenuItem.Enabled = this.IsActiveTournament && flag10 && (flag4 && flag2) && !flag6;
      this.menuPlayerUndropPlayerWizardToolStripMenuItem.Enabled = this.IsActiveTournament && activeTournament.CurrentRound > 1;
      this.toolStripButton_WizardUndropPlayer.Enabled = this.IsActiveTournament && activeTournament.CurrentRound > 1;
      this.menuPairingsChangeMatchResultWizardToolStripMenuItem.Enabled = flag7 && flag10;
      this.toolStripButton_WizardChangeResult.Enabled = flag7 && flag10;
      this.menuTournamentbatchPrintingToolStripMenuItem.Enabled = this.IsActiveTournament;
      this.toolStripButton_BatchPrint.Enabled = this.IsActiveTournament;
      this.menuTournImportMatchResultsFromASeparateFileToolStripMenuItem.Enabled = this.IsActiveTournament && flag4;
      this.menuPairingsPrintPaireddownPlayersToolStripMenuItem.Enabled = flag1;
      this.setPairingsPrintoutRangesToolStripMenuItem.Enabled = this.IsActiveTournament;
      this.seatAllPlayersToolStripMenuItem.Enabled = this.IsActiveTournament && flag5;
      this.btnClearPlayer.Enabled = Engine.CurrentPlayerSelected || this.txtCurrentPlayerID.Text.Length > 0 || this.txtCurrentPlayerFirstName.Text.Length > 0 || this.txtCurrentPlayerLastName.Text.Length > 0;
      this.btnDropPlayer.Enabled = Engine.CurrentPlayerSelected && this.IsActiveTournament && flag10;
      if (flag8 && flag4 && flag10)
      {
        this.btnEnrollPlayer.Enabled = false;
        this.btnTempID.Enabled = false;
      }
      else if (flag9)
      {
        this.btnEnrollPlayer.Enabled = false;
        this.btnTempID.Enabled = false;
      }
      else if (!this.IsActiveTournament)
      {
        this.btnEnrollPlayer.Enabled = false;
        this.btnTempID.Enabled = false;
      }
      else
      {
        this.btnEnrollPlayer.Enabled = Engine.CurrentPlayerSelected || this._PlayerIdEntered;
        this.btnTempID.Enabled = this.txtCurrentPlayerID.Text.Length == 0;
      }
      this.listEnrolledPlayers.Enabled = this.IsActiveTournament;
      if (this.IsActiveTournament)
        this.listEnrolledPlayers.BackColor = Color.White;
      else
        this.listEnrolledPlayers.BackColor = Color.LightGray;
      this.btnToolStrip_PairRound.Enabled = flag10 && flag1 && (flag2 || flag3) && flag11;
      this.btnToolStrip_RepairRound.Enabled = flag10 && flag1 && flag4;
      this.tournamentPairNextRoundToolStripMenuItem.Enabled = flag10 && flag1 && (flag2 || flag3) && flag11;
      this.btnToolStrip_PairPlayoffs.Enabled = flag10 && flag1 && (flag2 && !flag8) && flag11;
      this.tournamentCutToPlayoffsToolStripMenuItem.Enabled = flag10 && flag1 && (flag2 && !flag8) && flag11;
      this.btnToolStrip_CancelRound.Enabled = flag4 && flag10;
      this.btnToolStrip_PrintPairings.Enabled = flag4;
      this.btnToolStrip_PrintPlayers.Enabled = flag5;
      this.btnToolStrip_PrintBrackets.Enabled = flag4;
      this.btnToolStrip_PrintResultSlips.Enabled = flag4;
      this.btnToolStrip_PrintStandings.Enabled = flag7;
      this.btnToolStrip_ViewPairings.Enabled = this.btnToolStrip_PrintPairings.Enabled;
      this.btnToolStrip_ViewPlayers.Enabled = this.IsActiveTournament;
      this.btnToolStrip_ViewStandings.Enabled = this.btnToolStrip_PrintStandings.Enabled;
    }

    private void OpenDuelingHighlightPlayer(IPlayer player)
    {
      this.dgOpenDueling.ClearSelection();
      foreach (DataGridViewRow row in (IEnumerable) this.dgOpenDueling.Rows)
      {
        if (((IPlayer) row.Cells["TournPlayer"].Value).ID == player.ID)
        {
          row.Selected = true;
          break;
        }
      }
    }

    private void OpenDuelingKeyDown(KeyEventArgs e)
    {
      bool flag = e.KeyCode == Keys.Oemplus || e.KeyCode == Keys.Return || e.KeyCode == Keys.Return || e.KeyCode == Keys.Add;
      bool subtractPoint = e.KeyCode == Keys.Subtract || e.KeyCode == Keys.OemMinus;
      if (flag || subtractPoint)
      {
        this.AddSubtractOpenDuelingPoint(subtractPoint);
        e.Handled = true;
      }
      else
      {
        if (e.KeyCode == Keys.Down)
        {
          if (this.dgOpenDueling.SelectedRows.Count > 0)
          {
            int index = this.dgOpenDueling.SelectedRows[0].Index + 1;
            if (index == this.dgOpenDueling.Rows.Count)
            {
              e.Handled = true;
              return;
            }
            this.dgOpenDueling.ClearSelection();
            this.dgOpenDueling.FirstDisplayedScrollingRowIndex = index;
            this.dgOpenDueling.Refresh();
            this.dgOpenDueling.CurrentCell = this.dgOpenDueling.Rows[index].Cells[0];
            this.dgOpenDueling.Rows[index].Selected = true;
            Engine.CurrentPlayer = (IPlayer) this.dgOpenDueling.Rows[index].Cells["TournPlayer"].Value;
            this.ShowOpenDuelingPlayer();
            this.txtOpenDuelingFirstname.SelectAll();
            this.txtOpenDuelingLastName.SelectAll();
          }
          e.Handled = true;
        }
        if (e.KeyCode != Keys.Up)
          return;
        if (this.dgOpenDueling.SelectedRows.Count > 0)
        {
          int index = this.dgOpenDueling.SelectedRows[0].Index - 1;
          if (index < 0)
          {
            e.Handled = true;
            return;
          }
          this.dgOpenDueling.ClearSelection();
          this.dgOpenDueling.FirstDisplayedScrollingRowIndex = index;
          this.dgOpenDueling.Refresh();
          this.dgOpenDueling.CurrentCell = this.dgOpenDueling.Rows[index].Cells[0];
          this.dgOpenDueling.Rows[index].Selected = true;
          Engine.CurrentPlayer = (IPlayer) this.dgOpenDueling.Rows[index].Cells["TournPlayer"].Value;
          this.ShowOpenDuelingPlayer();
          this.txtOpenDuelingFirstname.SelectAll();
          this.txtOpenDuelingLastName.SelectAll();
        }
        e.Handled = true;
      }
    }

    private void OpenDuelingKeyUp(
      KeyEventArgs e,
      TextBox txtFocused,
      TextBox txtOther,
      bool firstNameFocused)
    {
      if (!Utility.IsPrintableCharacter(e.KeyCode))
      {
        e.Handled = true;
      }
      else
      {
        IPlayer player = (!firstNameFocused ? Engine.PlayerList.MatchName(txtOther.Text, txtFocused.Text, firstNameFocused) : Engine.PlayerList.MatchName(txtFocused.Text, txtOther.Text, firstNameFocused)) ?? (!firstNameFocused ? Engine.PlayerList.MatchName(txtOther.Text, "", firstNameFocused) : Engine.PlayerList.MatchName(txtFocused.Text, "", firstNameFocused));
        if (player == null)
        {
          txtFocused.SelectedText = string.Empty;
          txtOther.SelectedText = string.Empty;
          Engine.CurrentPlayer = (IPlayer) null;
          this.dgOpenDueling.ClearSelection();
        }
        else
        {
          int selectionStart = txtFocused.SelectionStart;
          Engine.CurrentPlayer = player;
          if (firstNameFocused)
          {
            txtFocused.Text = player.FirstName;
            txtOther.Text = player.LastName;
          }
          else
          {
            txtFocused.Text = player.LastName;
            txtOther.Text = player.FirstName;
          }
          txtFocused.Focus();
          txtFocused.Select(selectionStart, txtFocused.Text.Length - selectionStart);
          txtOther.SelectAll();
          this.OpenDuelingHighlightPlayer(player);
          int num = this.listNameLookup.Items.IndexOf((object) Engine.CurrentPlayer);
          if (num <= 0)
            return;
          this.listNameLookup.TopIndex = num;
          this.listNameLookup.SelectedIndex = num;
        }
      }
    }

    private void OpenTournament()
    {
      string[] strArray = this._OpenMultipleTournaments();
      if (strArray == null)
        return;
      this.WaitCursor(true);
      foreach (string filename in strArray)
      {
        ITournament tournament = (ITournament) this._OpenTournament(filename);
        if (Engine.AllTournaments.FindById(tournament.ID) == null)
        {
          IPlayerArray players = this._AddPlayersAndStaff(tournament);
          if (players.Count > 0)
            this._ShowAdditionalPlayers(players);
          Engine.AllTournaments.Add(tournament);
          this.tabTournaments.TabPages.Add(tournament.ID, tournament.Name);
          int index = this.tabTournaments.TabPages.IndexOfKey(tournament.ID);
          if (index < this.tabTournaments.TabPages.Count)
            this.tabTournaments.SelectTab(index);
          if (tournament.Matches.Count > 0)
            this.ShowPanel(MainForm.PanelTypes.Matches);
          else
            this.ShowPanel(MainForm.PanelTypes.EnrollPlayer);
          Engine.PlayerList.Append(tournament.Players.Downgrade());
          Engine.LocationList.Sort();
          if (tournament.Location.Name.Trim().Length > 0 && Engine.LocationList.FindById(tournament.Location.Id) == null)
            Engine.LocationList.Add(tournament.Location);
          this.AddTournamentToOpenMenu(tournament);
        }
      }
      MainForm._SavePlayerList(true);
      this.UI_Cleanup();
      this.WaitCursor(false);
      int num = (int) MessageBox.Show("Tournament Opened");
    }

    private void PairPlayoffs()
    {
      ITournament activeTournament = this.ActiveTournament;
      if (activeTournament == null)
        return;
      DialogPlayoffs dialogPlayoffs = new DialogPlayoffs();
      dialogPlayoffs.PlayoffCount = (int) Math.Min(8.0, Math.Pow(2.0, Math.Floor(Math.Log((double) activeTournament.Players.Count, 2.0))));
      if (dialogPlayoffs.ShowDialog() != DialogResult.OK)
        return;
      if (dialogPlayoffs.IsDay2Cut)
      {
        if (dialogPlayoffs.Day2Record <= 0)
          return;
        this.WaitCursor(true);
        activeTournament.CutPlayers(dialogPlayoffs.Day2Record, CutType.Cut);
        this._PairNextRound(activeTournament, false);
        this.WaitCursor(false);
      }
      else if (dialogPlayoffs.IsSingleElimCut)
      {
        this.WaitCursor(true);
        activeTournament.CutPlayers(dialogPlayoffs.PlayoffCount, CutType.PlayoffCut);
        activeTournament.PlayoffRound = activeTournament.CurrentRound + 1;
        this._PairNextRound(activeTournament, false);
        this.WaitCursor(false);
      }
      else
      {
        if (!dialogPlayoffs.IsTopXCut)
          return;
        this.WaitCursor(true);
        activeTournament.CutPlayers(dialogPlayoffs.TopXCut, CutType.TopX);
        this._PairNextRound(activeTournament, false);
        this.WaitCursor(false);
      }
      this.UI_Cleanup();
    }

    private void panelPlayerEntry_VisibleChanged(object sender, EventArgs e)
    {
      if (!this.panelPlayerEntry.Visible)
        return;
      this.txtCurrentPlayerID.Focus();
    }

    private void panelResultsEntry_VisibleChanged(object sender, EventArgs e)
    {
      if (!this.panelResultsEntry.Visible)
        return;
      this.UI_MatchResultsTableHightlight();
    }

    private void panelStandings_VisibleChanged(object sender, EventArgs e)
    {
      if (!this.panelStandings.Visible)
        return;
      this.ddlStandingsRound.Items.Clear();
      if (!this.IsActiveTournament)
        return;
      ITournament activeTournament = this.ActiveTournament;
      for (int index = activeTournament.CurrentRound - 1; index > 0; --index)
        this.ddlStandingsRound.Items.Add((object) index.ToString());
      if (activeTournament.Matches.UnreportedMatches.Count == 0)
        this.ddlStandingsRound.Items.Insert(0, (object) activeTournament.CurrentRound.ToString());
      if (this.ddlStandingsRound.Items.Count <= 0)
        return;
      this.ddlStandingsRound.SelectedIndex = 0;
    }

    private void RemoveTournamentFromOpenMenu(ITournament t)
    {
      for (int index = 0; index < this.menuItemCurrentTournamentsToolStripMenuItem.DropDownItems.Count; ++index)
      {
        string str = this.menuItemCurrentTournamentsToolStripMenuItem.DropDownItems[index].Tag.ToString();
        if (t.ID == str)
          this.menuItemCurrentTournamentsToolStripMenuItem.DropDownItems.RemoveAt(index);
      }
    }

    private void SetVisiblePanels(MainForm.PanelTypes type)
    {
      this.panelResultsEntry.Visible = type == MainForm.PanelTypes.Matches;
      this.panelOpenDueling.Visible = type == MainForm.PanelTypes.OpenDueling;
      this.panelPlayerEntry.Visible = type == MainForm.PanelTypes.EnrollPlayer;
      this.panelStandings.Visible = type == MainForm.PanelTypes.Standings;
      if (this.panelResultsEntry.Visible)
        this.panelResultsEntry.BringToFront();
      if (this.panelOpenDueling.Visible)
        this.panelOpenDueling.BringToFront();
      if (this.panelPlayerEntry.Visible)
        this.panelPlayerEntry.BringToFront();
      if (!this.panelStandings.Visible)
        return;
      this.panelStandings.BringToFront();
    }

    private void ShowOpenDuelingPlayer()
    {
      if (this.dgOpenDueling.SelectedRows.Count <= 0)
        return;
      TournPlayer tournPlayer = (TournPlayer) this.dgOpenDueling.SelectedRows[0].Cells["TournPlayer"].Value;
      if (tournPlayer == null)
        return;
      Engine.CurrentPlayer = (IPlayer) tournPlayer;
      this.txtOpenDuelingFirstname.Text = tournPlayer.FirstName;
      this.txtOpenDuelingLastName.Text = tournPlayer.LastName;
    }

    private void ShowPanel(MainForm.PanelTypes type)
    {
      MainForm.PanelTypes panelTypes = type;
      if (this.IsActiveTournament)
        this._PanelsSetPanel(this.ActiveTournament, panelTypes);
      else
        panelTypes = MainForm.PanelTypes.EnrollPlayer;
      this.SetVisiblePanels(panelTypes);
      switch (panelTypes)
      {
        case MainForm.PanelTypes.EnrollPlayer:
          this._ShowEnrolledPlayers();
          this._ClearPlayerTextBoxes();
          this.txtCurrentPlayerID.Focus();
          break;
        case MainForm.PanelTypes.Matches:
          this._UpdateRoundDropDownList();
          this._ShowPairings(this.RoundFromDropDownList);
          this.UI_UpdateResultsEntry();
          break;
        case MainForm.PanelTypes.Standings:
          if (this.IsActiveTournament && this.ActiveTournament.PairingStructure == TournamentPairingStructure.OpenDueling)
            this.SetVisiblePanels(MainForm.PanelTypes.OpenDueling);
          this._ShowStandings(this.ActiveTournament);
          break;
        case MainForm.PanelTypes.OpenDueling:
          this.SetVisiblePanels(MainForm.PanelTypes.OpenDueling);
          this._ShowStandings(this.ActiveTournament);
          break;
      }
      this.UI_Cleanup();
    }

    private void ShowPenalties()
    {
      this.ShowPenalties((IPlayer) null);
    }

    private void ShowPenalties(IPlayer preselectedPlayer)
    {
      ITournament activeTournament = this.ActiveTournament;
      if (activeTournament == null)
        return;
      int num = (int) new DialogPenalties()
      {
        PreselectedPlayer = preselectedPlayer,
        currentTournament = activeTournament
      }.ShowDialog();
      Engine.SaveTournamentToFile(activeTournament);
    }

    private void ShowPrintPairingsDialog(Engine.PrintPairingsAction action)
    {
      ITournament activeTournament = this.ActiveTournament;
      if (activeTournament == null)
        return;
      if (this.RoundFromDropDownList == -1)
      {
        int num1 = (int) MessageBox.Show("Invalid round selected");
      }
      else
      {
        string selectedPrinter = this.printDocPairings.PrinterSettings.PrinterName;
        int copies = this._maxPrintCopy;
        Engine.PrintPairingsAction currentPairingsPrint = action;
        switch (action)
        {
          case Engine.PrintPairingsAction.PrintByTable:
          case Engine.PrintPairingsAction.PrintByPlayer:
          case Engine.PrintPairingsAction.PrintBrackets:
            DialogPrintPairings dialogPrintPairings = new DialogPrintPairings();
            dialogPrintPairings.SelectedPrinter = selectedPrinter;
            dialogPrintPairings.Copies = this._maxPrintCopy;
            dialogPrintPairings.PrintByPlayer = action == Engine.PrintPairingsAction.PrintByPlayer;
            dialogPrintPairings.PrintByTable = action == Engine.PrintPairingsAction.PrintByTable;
            dialogPrintPairings.PrintBrackets = action == Engine.PrintPairingsAction.PrintBrackets;
            int num2 = (int) dialogPrintPairings.ShowDialog();
            if (dialogPrintPairings.DialogResult != DialogResult.OK)
              return;
            selectedPrinter = dialogPrintPairings.SelectedPrinter;
            copies = dialogPrintPairings.Copies;
            currentPairingsPrint = !dialogPrintPairings.PrintBrackets ? (!dialogPrintPairings.PrintByPlayer ? Engine.PrintPairingsAction.PrintByTable : Engine.PrintPairingsAction.PrintByPlayer) : Engine.PrintPairingsAction.PrintBrackets;
            break;
          case Engine.PrintPairingsAction.RandomMatches:
            DialogSimpleTextBox dialogSimpleTextBox = new DialogSimpleTextBox();
            dialogSimpleTextBox.Bind("Print Random Tables", "Please enter the number of tables", "");
            if (dialogSimpleTextBox.ShowDialog() != DialogResult.OK)
              return;
            if (dialogSimpleTextBox.IsIntInput)
            {
              copies = dialogSimpleTextBox.IntInput;
              break;
            }
            int num3 = (int) MessageBox.Show("Unable to read table number, please try again");
            return;
        }
        this._PrintPairings(activeTournament, currentPairingsPrint, copies, selectedPrinter);
      }
    }

    private void ShowPrintPlayerNotesDialog()
    {
      ITournament activeTournament = this.ActiveTournament;
      if (activeTournament == null || this.dlgPrint.ShowDialog() != DialogResult.OK)
        return;
      this.printDocPlayerNotes.DocumentName = string.Format("{0} - Player Penalties", (object) activeTournament.Name);
      this.printDocPlayerNotes.PrinterSettings = this.dlgPrint.PrinterSettings;
      this._currentPrintPage = 1;
      this._currentPrintPlayerNotes = 0;
      this.printDocPlayerNotes.Print();
    }

    private void ShowPrintPlayersDialog()
    {
      if (!this.IsActiveTournament)
        return;
      ITournament activeTournament = this.ActiveTournament;
      if (this.dlgPrintPlayers.ShowDialog() != DialogResult.OK)
        return;
      this.dlgPrint.PrinterSettings = this.printDocPlayerList.PrinterSettings;
      if (this.dlgPrint.ShowDialog() != DialogResult.OK)
        return;
      Engine.LogAction(activeTournament, UserAction.Print_Player_List);
      this._currentPrintPage = 0;
      this.printDocPlayerList.PrinterSettings = this.dlgPrint.PrinterSettings;
      string str = this.dlgPrintPlayers.AllPlayers ? "All Players" : "Active Players";
      this.printDocPlayerList.DocumentName = activeTournament.Name + " : " + str;
      this.printDocPlayerList.Print();
    }

    private void ShowPrintResultSlipsDialog()
    {
      if (!this.IsActiveTournament)
        return;
      ITournament activeTournament = this.ActiveTournament;
      DialogResultSlips dialogResultSlips = new DialogResultSlips();
      dialogResultSlips.TargetTournament = activeTournament;
      if (dialogResultSlips.ShowDialog() != DialogResult.OK)
        return;
      this.dlgPrint.PrinterSettings = this.printDocResultSlips.PrinterSettings;
      if (this.dlgPrint.ShowDialog() != DialogResult.OK)
        return;
      this.printDocResultSlips.PrinterSettings = this.dlgPrint.PrinterSettings;
      Engine.LogAction(activeTournament, UserAction.Print_Result_Slips);
      this._PrintResultSlips(activeTournament, dialogResultSlips.Matches, this.dlgPrint.PrinterSettings.PrinterName);
    }

    private void tabTournaments_ControlAdded(object sender, ControlEventArgs e)
    {
      this.UI_UpdateTabControlHeight();
    }

    private void tabTournaments_ControlRemoved(object sender, ControlEventArgs e)
    {
      this.UI_UpdateTabControlHeight();
    }

    private void TournamentClose(ITournament tourn)
    {
      if (tourn == null)
        return;
      Engine.LogAction(tourn, UserAction.Tourn_Close);
      Engine.SaveTournamentToFile(tourn);
      int val1 = this.tabTournaments.TabPages.IndexOfKey(tourn.ID);
      this.tabTournaments.TabPages.RemoveByKey(tourn.ID);
      Engine.AllTournaments.Remove(tourn);
      this.RemoveTournamentFromOpenMenu(tourn);
      int index = Math.Max(0, Math.Min(val1, this.tabTournaments.TabPages.Count - 1));
      if (index < this.tabTournaments.TabCount)
        this.tabTournaments.SelectTab(index);
      else if (this.tabTournaments.TabCount == 1)
        this.tabTournaments.SelectedIndex = 0;
      else
        this.tabTournaments.SelectedIndex = -1;
    }

    private void TournamentCreate()
    {
      TournamentSettings tournamentSettings = new TournamentSettings();
      tournamentSettings.ThisTournament = (ITournament) new Tournament();
      if (tournamentSettings.ShowDialog() != DialogResult.OK)
        return;
      ITournament thisTournament = tournamentSettings.ThisTournament;
      Engine.LogAction(thisTournament, UserAction.Tourn_New);
      Engine.SaveTournamentToFile(thisTournament);
      Engine.AllTournaments.Add(thisTournament);
      this.RemoveTournamentFromOpenMenu(thisTournament);
      this.AddTournamentToOpenMenu(thisTournament);
      this.tabTournaments.TabPages.Add(thisTournament.ID, thisTournament.Name);
      this.tabTournaments.SelectTab(thisTournament.ID);
      this._AddStaffToPlayerList(thisTournament);
      this.ShowPanel(MainForm.PanelTypes.EnrollPlayer);
      this._ClearPlayerTextBoxes();
      this.txtCurrentPlayerID.Focus();
      this.UI_Cleanup();
    }

    private void TournamentUpdate()
    {
      if (!this.IsActiveTournament)
        return;
      ITournament activeTournament = this.ActiveTournament;
      TournamentSettings tournamentSettings = new TournamentSettings();
      tournamentSettings.ThisTournament = (ITournament) new Tournament();
      tournamentSettings.ThisTournament.CopySettings(activeTournament, true);
      tournamentSettings.AcceptButtonText = "Update";
      if (tournamentSettings.ShowDialog() != DialogResult.OK)
        return;
      Engine.LogAction(activeTournament, UserAction.Tourn_Update);
      string id = activeTournament.ID;
      string filename = activeTournament.Filename;
      activeTournament.CopySettings(tournamentSettings.ThisTournament, true);
      Engine.SaveTournamentToFile(activeTournament);
      if (id != activeTournament.ID)
        File.Delete(Path.Combine(TournamentLibrary.BusinessLogic.Settings.DataStorageFolder, filename));
      TabPage tabByTournamentId = this.GetTabByTournamentID(id);
      if (tabByTournamentId != null)
      {
        tabByTournamentId.Name = activeTournament.ID;
        tabByTournamentId.Text = activeTournament.Name;
      }
      MainForm._SavePlayerList(true);
      this.UI_Cleanup();
    }

    private void UpdateGlobalPlayerCount()
    {
      if (Engine.PlayerList.Count > this.listNameLookup.Items.Count)
        this.lblPlayerCount.Text = string.Format("{0} Global Players (showing {1})", (object) Engine.PlayerList.Count, (object) this.listNameLookup.Items.Count);
      else
        this.lblPlayerCount.Text = string.Format("{0} Global Players", (object) Engine.PlayerList.Count);
    }

    private void WaitCursor(bool wait)
    {
      if (wait)
      {
        if (this.Cursor != Cursors.WaitCursor)
          this._oldCursor = this.Cursor;
        this.Cursor = Cursors.WaitCursor;
      }
      else
        this.Cursor = this._oldCursor;
    }

    private enum PanelTypes
    {
      EnrollPlayer = 1,
      Matches = 2,
      Standings = 3,
      OpenDueling = 4,
      None = 5,
    }
  }
}
