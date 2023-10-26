const { pathsToModuleNameMapper } = require('ts-jest')
const { compilerOptions } = require('./tsconfig')
/** @type {import('ts-jest/dist/types').InitialOptionsTsJest} */
module.exports = {
  preset: 'ts-jest',
  testEnvironment: 'jsdom',
  setupFilesAfterEnv: ['<rootDir>/jest-setup.ts'],
  moduleNameMapper: {
    ...pathsToModuleNameMapper(
      compilerOptions.paths,
      { prefix: '<rootDir>/src/' },
    ),
  },
  testPathIgnorePatterns: [
    "/externals/",
    "/node_modules/", 
    "(.*)index.ts$", 
    "/__test__/"
  ],
  coveragePathIgnorePatterns: [
    "/externals/",
    "/node_modules/", 
    "/examples/",
    "(.*)index.ts$", 
    "/__test__/",
  ]
};
