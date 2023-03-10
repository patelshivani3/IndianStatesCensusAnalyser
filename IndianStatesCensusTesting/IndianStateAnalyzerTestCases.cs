using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using IndianStatesCensusAnalyser;
using IndianStatesCensusAnalyser.DTO;
using System.Collections.Generic;

namespace IndianStatesCensusTesting
{
    [TestClass]
    public class IndianStateAnalyzerTestCases
    {
        //UC1 - File Paths for indian state census
        string stateCensusFilePath = @"C:\Users\shivp\source\repos\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CSVFiles\IndianPopulation.csv";
        string wrongFilePath = @"C:\Users\shivp\source\repos\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CSVFiles\WrongIndianPopulation.csv";
        string wrongTypeFilePath = @"C:\Users\shivp\source\repos\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CSVFiles\IndiaStateCode.txt";
        string wrongDelimiterFilePath = @"C:\Users\shivp\source\repos\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CSVFiles\DelimiterIndiaStateCensusData.csv";
        string wrongHeaderFilePath = @"C:\Users\shivp\source\repos\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CSVFiles\WrongIndiaStateCensusData.csv";
        string stateCensusHeader = "State,Population,AreaInSqKm,DensityPerSqKm";

        //UC2 - File paths for indian state codes
        string statCodeFilePath = @"C:\Users\shivp\source\repos\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CSVFiles\IndiaStateCode.csv";
        string wrongStateCodeFilePath = @"C:\Users\shivp\source\repos\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CSVFiles\IndiaStateCode.csv";
        string wrongStateCodeTypeFilePath = @"C:\Users\shivp\source\repos\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CSVFiles\IndiaStateCode.txt";
        string wrongStateCodeDelimiterFilePath = @"C:\Users\shivp\source\repos\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CSVFiles\DelimiterIndiaStateCode.csv";
        string wrongStateCodeHeaderFilePath = @"C:\Users\shivp\source\repos\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CSVFiles\WrongIndiaStateCode.csv";
        string stateCodeHeader = "SrNo,State Name,TIN,StateCode";

        CSVAdapterFactory csvAdapter;
        Dictionary<string, CensusDTO> stateRecords;
        Dictionary<string, CensusDTO> stateCodeRecords;

        [TestInitialize]
        public void SetUp()
        {
            csvAdapter = new CSVAdapterFactory();
            stateRecords = new Dictionary<string, CensusDTO>();
            stateCodeRecords = new Dictionary<string, CensusDTO>();
        }

        //TC 1.1 Given correct path To ensure number of records matches
        [TestMethod]
        public void GivenStateCensusCsvReturnStateRecords()
        {
            int expected = 29;
            stateRecords = csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, stateCensusFilePath, stateCensusHeader);
            Assert.AreEqual(expected, stateRecords.Count);
        }

        //TC 1.2 Given incorrect file should return custom exception - File not found
        [TestMethod]
        public void GivenWrongFileReturnCustomException()
        {
            var expected = CensusAnalyserException.ExceptionType.FILE_NOT_FOUND;
            var customException = Assert.ThrowsException<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongFilePath, stateCensusHeader));
            Assert.AreEqual(expected, customException.exception);
        }

        //TC 1.3 Given correct path but incorrect file type should return custom exception - Invalid file type
        [TestMethod]
        public void GivenWrongFileTypeReturnCustomException()
        {
            var expected = CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE;
            var customException = Assert.ThrowsException<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongTypeFilePath, stateCensusHeader));
            Assert.AreEqual(expected, customException.exception);
        }

        //TC 1.4 Given correct path but wrong delimiter should return custom exception - File Containers Wrong Delimiter
        [TestMethod]
        public void GivenWrongDelimiterReturnCustomException()
        {
            var expected = CensusAnalyserException.ExceptionType.INCOREECT_DELIMITER;
            var customException = Assert.ThrowsException<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongDelimiterFilePath, stateCensusHeader));
            Assert.AreEqual(expected, customException.exception);
        }

        //TC 1.5 Given correct path but wrong header should return custom exception - Incorrect header in Data
        [TestMethod]
        public void GivenWrongHeaderReturnCustomException()
        {
            var expected = CensusAnalyserException.ExceptionType.INCORRECT_HEADER;
            var customException = Assert.ThrowsException<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongHeaderFilePath, stateCensusHeader));
            Assert.AreEqual(expected, customException.exception);
        }
        //TC 2.1 Given correct path To ensure number of records matches
        [TestMethod]
        [TestCategory("Indian State Codes")]
        public void GivenStateCodesCsvReturnStateRecords()
        {
            int expected = 37;
            stateCodeRecords = csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, statCodeFilePath, stateCodeHeader);
            Assert.AreEqual(expected, stateCodeRecords.Count);
        }

        //TC 2.2 Given incorrect file should return custom exception - File not found
        [TestMethod]
        [TestCategory("Indian State Codes")]
        public void GivenStateCodesWrongFileReturnCustomException()
        {
            var expected = CensusAnalyserException.ExceptionType.FILE_NOT_FOUND;
            var customException = Assert.ThrowsException<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongStateCodeFilePath, stateCodeHeader));
            Assert.AreEqual(expected, customException.exception);
        }

        //TC 2.3 Given correct path but incorrect file type should return custom exception - Invalid file type
        [TestMethod]
        [TestCategory("Indian State Codes")]
        public void GivenStateCodesWrongFileTypeReturnCustomException()
        {
            var expected = CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE;
            var customException = Assert.ThrowsException<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongStateCodeTypeFilePath, stateCodeHeader));
            Assert.AreEqual(expected, customException.exception);
        }

        //TC 2.4 Given correct path but wrong delimiter should return custom exception - File Containers Wrong Delimiter
        [TestMethod]
        [TestCategory("Indian State Codes")]
        public void GivenStateCodesWrongDelimiterReturnCustomException()
        {
            var expected = CensusAnalyserException.ExceptionType.INCOREECT_DELIMITER;
            var customException = Assert.ThrowsException<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongStateCodeDelimiterFilePath, stateCodeHeader));
            Assert.AreEqual(expected, customException.exception);
        }

        //TC 2.5 Given correct path but wrong header should return custom exception - Incorrect header in Data
        [TestMethod]
        [TestCategory("Indian State Codes")]
        public void GivenStateCodesWrongHeaderReturnCustomException()
        {
            var expected = CensusAnalyserException.ExceptionType.INCORRECT_HEADER;
            var customException = Assert.ThrowsException<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongStateCodeHeaderFilePath, stateCodeHeader));
            Assert.AreEqual(expected, customException.exception);
        }

    }
}
