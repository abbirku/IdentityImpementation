using HtmlAgilityPack;
using Infrastructure.BusinessObject;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Infrastructure.Services
{
    public interface IParseFormWeb
    {
        bool IsMarketOpen();
        List<string> TraverseWeb();
        List<StockExchangeInfo> ParseStockExchangeInfo(List<string> exchangeInfo);
    }

    public class ParseFormWeb : IParseFormWeb
    {
        private readonly HtmlWeb _htmlWeb;
        private readonly SettingsConfig _settingsConfig;
        private HtmlDocument _htmlDoc;

        public ParseFormWeb(SettingsConfig settingsConfig)
        {
            _settingsConfig = settingsConfig;
            _htmlWeb = new HtmlWeb();
        }

        private List<HtmlNode> GetTraversedNode(string args)
        {
            try
            {
                _htmlDoc = _htmlWeb.Load(_settingsConfig.WebAddress);
                return _htmlDoc.DocumentNode.SelectNodes(args).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool IsMarketOpen()
        {
            try
            {
                var data = GetTraversedNode("//body/div/div/div/header/div[@class='HeaderTop']//span/b").FirstOrDefault();
                if (data != null)
                    return !data.InnerText.ToLower().Equals("Closed".ToLower());
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<string> TraverseWeb()
        {
            try
            {
                var webNodeList = GetTraversedNode("//div[@id='RightBody']/div/div/div/table/tr");

                var theFirst = GetTraversedNode("//div[@id='RightBody']/div/div/div/table/tbody/tr");
                if (theFirst.FirstOrDefault() != null)
                    webNodeList.Insert(0, theFirst.FirstOrDefault());

                var webInnerTextList = webNodeList.Select(x => Regex.Replace(Regex.Replace(x.InnerText, @"\t+", ""), @"\n+", "=")).ToList();

                return webInnerTextList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<StockExchangeInfo> ParseStockExchangeInfo(List<string> exchangeInfos)
        {
            try
            {
                var list = new List<StockExchangeInfo>();

                foreach (var item in exchangeInfos)
                {
                    var parts = item.Split('=').ToList();
                    parts.RemoveAll(x => string.IsNullOrEmpty(x));
                    parts[10] = parts[10].Replace(",", "");

                    var info = new StockExchangeInfo
                    {
                        TradingCode = parts[1],
                        LTP = decimal.Parse(parts[2].Equals("--")?"0": parts[2]),
                        High = decimal.Parse(parts[3].Equals("--") ? "0" : parts[3]),
                        Low = decimal.Parse(parts[4].Equals("--") ? "0" : parts[4]),
                        CloseUp = decimal.Parse(parts[5].Equals("--") ? "0" : parts[5]),
                        YCP = decimal.Parse(parts[6].Equals("--") ? "0" : parts[6]),
                        Change = decimal.Parse(parts[7].Equals("--") ? "0" : parts[7]),
                        Trade = decimal.Parse(parts[8].Equals("--") ? "0" : parts[8]),
                        Value = decimal.Parse(parts[9].Equals("--") ? "0" : parts[9]),
                        Volume = decimal.Parse(parts[10].Equals("--") ? "0" : parts[10])
                    };

                    list.Add(info);
                }

                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
