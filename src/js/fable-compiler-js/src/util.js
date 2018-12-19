const fs = require("fs");
const Path = require("path");
const Babel = require("@babel/core");
const BabelPlugins = require("fable-babel-plugins");

const FSHARP_EXT = /\.(fs|fsx)$/i;

function ensureArray(obj) {
    return (Array.isArray(obj) ? obj : obj != null ? [obj] : []);
}

function getRelPath(fromPath, toPath) {
    let relPath = Path.relative(Path.dirname(fromPath), toPath);
    relPath = relPath.replace(/\\/g, "/").replace(FSHARP_EXT, "");
    relPath = relPath.endsWith(".js") ? relPath : relPath + ".js";
    return relPath.startsWith("..") ? relPath : "./" + relPath;
}

function fixImportPaths(babelAst, sourcePath) {
    const decls = ensureArray(babelAst.body);
    for (const decl of decls) {
        if (decl.source != null && typeof decl.source.value === "string") {
            const importPath = decl.source.value;
            if (importPath.startsWith("fable-library/") || importPath.match(FSHARP_EXT)) {
                decl.source.value = getRelPath(sourcePath, importPath);
            }
        }
    }
}

export function getVersion() {
    return require("../package.json").version;
}

export function ensureDirExists(dir, cont) {
    if (fs.existsSync(dir)) {
        if (typeof cont === "function") { cont(); }
    } else {
        ensureDirExists(Path.dirname(dir), () => {
            if (!fs.existsSync(dir)) { fs.mkdirSync(dir); }
            if (typeof cont === "function") { cont(); }
        });
    }
}

export function copyFolder(from, dest) {
    if (!fs.existsSync(dest)) {
        ensureDirExists(dest);
    }
    fs.readdirSync(from).forEach(element => {
        if (fs.lstatSync(Path.join(from, element)).isDirectory()) {
            copyFolder(Path.join(from, element), Path.join(dest, element));
        } else {
            fs.copyFileSync(Path.join(from, element), Path.join(dest, element));
        }
    });
}

const customPlugins = [
    BabelPlugins.getRemoveUnneededNulls(),
    BabelPlugins.getTransformMacroExpressions(Babel.template)
];

export function transformAndSaveBabelAst(babelAst, fileName, outDir, commonjs) {
    try {
        // this solves a weird commonjs issue where some imports are not properly qualified
        babelAst = JSON.parse(JSON.stringify(babelAst)); // somehow this helps with that
        const jsPath = fileName.replace(FSHARP_EXT, ".js");
        const outPath = Path.join(outDir, jsPath);
        ensureDirExists(Path.dirname(outPath));
        fixImportPaths(babelAst, fileName);
        const plugins = commonjs ? customPlugins.concat("@babel/plugin-transform-modules-commonjs") : customPlugins;
        const res = Babel.transformFromAstSync(babelAst, null, { plugins });
        fs.writeFileSync(outPath, res.code);
    } catch (err) {
        console.error(err);
    }
}

export function runCmd(cmd) {
    var child_process = require("child_process");
    console.log(">", cmd);
    child_process.execSync(cmd, {
        stdio: "inherit"
    });
}