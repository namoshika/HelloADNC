/// <binding BeforeBuild='Run - Development' />
const CopyWebpackPlugin = require("copy-webpack-plugin");

module.exports = {
    entry: "./wwwroot/js/app.tsx",
    output: {
        filename: "./wwwroot/js/bundle.js"
    },
    devtool: "source-map",
    resolve: {
        extensions: [".ts", ".tsx", ".js"]
    },
    module: {
        loaders: [
            { test: /\.tsx?$/, loader: "ts-loader" }
        ]
    },
    plugins: [
        new CopyWebpackPlugin([
            { from: "node_modules/bootstrap/dist", to: "wwwroot/lib/bootstrap/" },
            { from: "node_modules/jquery/dist", to: "wwwroot/lib/jquery/" },
            { from: "node_modules/masonry-layout/dist", to: "wwwroot/lib/masonry/" }
        ])
    ]
}; 