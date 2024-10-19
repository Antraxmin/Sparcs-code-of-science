using UnityEngine;
using UnityEditor;
using UnityEngine.Tilemaps;

public class SpriteSheetToTiles
{
    [MenuItem("Tools/Sprite Sheet to Tiles")]
    public static void ConvertSpriteSheetToTiles()
    {
        // 스프라이트 시트를 선택하는 다이얼로그
        Texture2D spriteSheet = Selection.activeObject as Texture2D;

        if (spriteSheet == null)
        {
            Debug.LogError("Select a sprite sheet first.");
            return;
        }

        int tileWidth = 32; // 각 타일의 너비
        int tileHeight = 32; // 각 타일의 높이

        // 타일 에셋 저장할 폴더 생성
        string tileFolder = "Assets/Tiles";
        if (!AssetDatabase.IsValidFolder(tileFolder))
        {
            AssetDatabase.CreateFolder("Assets", "Tiles");
        }

        // 스프라이트 시트에서 타일 생성
        for (int y = 0; y < spriteSheet.height; y += tileHeight)
        {
            for (int x = 0; x < spriteSheet.width; x += tileWidth)
            {
                // 스프라이트 생성
                var sprite = Sprite.Create(spriteSheet, new Rect(x, y, tileWidth, tileHeight), new Vector2(0.5f, 0.5f));

                // 타일 에셋 생성
                Tile newTile = ScriptableObject.CreateInstance<Tile>();
                newTile.sprite = sprite;

                // 타일 에셋 파일 경로
                string tilePath = $"{tileFolder}/Tile_{x}_{y}.asset";
                AssetDatabase.CreateAsset(newTile, tilePath);
            }
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        Debug.Log("Tiles created successfully!");
    }
}
