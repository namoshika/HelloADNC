/// <binding ProjectOpened='Watch - Development' />
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
    }
};