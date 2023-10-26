const path = require('path');
const HtmlWebpackPlugin        = require('html-webpack-plugin');

console.log("process.env.NODE_ENV = ", process.env.NODE_ENV);

const config = {
	name: "client",
	mode: process.env.NODE_ENV,
	entry: {
		main: {
			import: './src/index.ts'
		}
	},
	output: {
		filename: 'js/[name].[hash].js',
		chunkFilename: 'js/[name].[chunkhash:8].js',
		path: path.resolve(__dirname, '../' , 'public'),
		publicPath: '/',		
	},
	devtool: 'eval-cheap-module-source-map',
	module: {
		rules: [
			{
				test: /\.ts$/,
				exclude: [/node_modules/],
				use: [
					{
						loader: 'ts-loader',
						options: {
							transpileOnly: true,
							configFile: 'tsconfig.json'
						}
					}
				],
			},
			{
                test: /\.(sc|c)ss$/,
                use: ["style-loader", "css-loader", "sass-loader"],
            },
			{
				test: /\.html$/i,
				loader: "html-loader",
			},
		]
	},
	resolve: {
		extensions: ['.ts', '.js', '.html'],
		alias: {
			'@externals': 	path.resolve(__dirname, 'externals'),
		},
	},
	externals: [],
	plugins: [
		new HtmlWebpackPlugin({
			filename: 'index.html',
			template: './src/index.html',
		}),
	],
	devServer: {	
		hot: true,	
		open: true,
		port: 4000,
		historyApiFallback: true,
	}
};

module.exports = [ config ];

// 目標：
// 1. Handout
// 2. Simple Code 要有答案
//     - Code stopCoverage
//     - Negitive Case
//     - Exception handling
//     - Boundary Test
//     - Performance Test
//     - Partition Testing
// 3. 程式語言 typescript、python
// 4. Tool
//     - jest
//     - cypress
//     - pytest
//     - robotiive
//     - gitlab DevOps
// 5. Unitest Mob Programming
//     - Google Doc 助教看狀況 => 讓學生給個 Feedback
//     - 防止作業亂抄
//     - 找一個主題
// 6. 時間 2/10
//     > 2/9 初稿
// 7. Geekynote 單元測試新的類別

