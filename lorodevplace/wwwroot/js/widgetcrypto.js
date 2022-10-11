﻿$(function () {
    getMarketData();
    setInterval(getMarketData, 10000);
});

function getMarketData() {
    getCryptoCompare();
}

function getCryptoCompare() {
    $.when(
        $.get("https://min-api.cryptocompare.com/data/pricemultifull?fsyms=BTC,ETH,DOGE,XRP,SHIB&tsyms=USD")
    ).done(function (data) {

        $("#btcLogo").html('<img class = "hola" src="https://cryptocompare.com' + data.RAW.BTC.USD.IMAGEURL + '">');
        $("#btcSymbol").text((data.RAW.BTC.USD.FROMSYMBOL).toLocaleString());
        $("#btcPrice").text((data.RAW.BTC.USD.PRICE).toLocaleString("en-US", { style: "currency", currency: "USD" }));
        $("#btcChange").text((data.RAW.BTC.USD.CHANGEPCT24HOUR).toFixed(2) + "%");
        $("#btcVol").text((data.RAW.BTC.USD.VOLUME24HOUR).toLocaleString("en-US", { style: "currency", currency: "USD" }));
        $("#btcCap").text((data.RAW.BTC.USD.MKTCAP).toLocaleString("en-US", { style: "currency", currency: "USD" }));
        $("#btcTime").text((new Date(data.RAW.BTC.USD.LASTUPDATE * 1000)).toLocaleString());
    

    $("#ethLogo").html('<img class= "hola" src="https://cryptocompare.com' + data.RAW.ETH.USD.IMAGEURL + '">');
    $("#ethSymbol").text((data.RAW.ETH.USD.FROMSYMBOL).toLocaleString());
    $("#ethPrice").text((data.RAW.ETH.USD.PRICE).toLocaleString("en-US", { style: "currency", currency: "USD" }));
    $("#ethChange").text((data.RAW.ETH.USD.CHANGEPCT24HOUR).toFixed(2) + "%");
    $("#ethVol").text((data.RAW.ETH.USD.VOLUME24HOUR).toLocaleString("en-US", { style: "currency", currency: "USD" }));
    $("#ethCap").text((data.RAW.ETH.USD.MKTCAP).toLocaleString("en-US", { style: "currency", currency: "USD" }));
        $("#ethTime").text((new Date(data.RAW.ETH.USD.LASTUPDATE * 1000)).toLocaleString());

        $("#shibLogo").html('<img class="hola" src="https://cryptocompare.com' + data.RAW.SHIB.USD.IMAGEURL + '">');
        $("#shibSymbol").text((data.RAW.SHIB.USD.FROMSYMBOL).toLocaleString());
        $("#shibPrice").text("$" + (data.RAW.SHIB.USD.PRICE).toFixed(6));
        $("#shibChange").text((data.RAW.SHIB.USD.CHANGEPCT24HOUR).toFixed(2) + "%");
        $("#shibVol").text((data.RAW.SHIB.USD.VOLUME24HOUR).toLocaleString("en-US", { style: "currency", currency: "USD" }));
        $("#shibCap").text((data.RAW.SHIB.USD.MKTCAP).toLocaleString("en-US", { style: "currency", currency: "USD" }));
        $("#shibTime").text((new Date(data.RAW.SHIB.USD.LASTUPDATE * 1000)).toLocaleString());
    });

   

}

$("#btcChange, #ethChange, #dogeChange, #xrpChange, #shibChange").bind("DOMSubtreeModified", function () {
    if ($(this).is(":contains('-')")) {
        $(this).removeClass("positive").addClass("negative");
    } else {
        $(this).removeClass("negative").addClass("positive");
    }
});
